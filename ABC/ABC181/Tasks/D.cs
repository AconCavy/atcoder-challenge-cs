using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var S = Scanner.Scan<string>();
            var answer = false;
            if (S.Length < 3)
            {
                if (S.Length == 1)
                {
                    answer |= int.Parse(S) % 8 == 0;
                }
                else
                {
                    var x = int.Parse(S);
                    answer |= x % 8 == 0;
                    var y = (S[1] - '0') * 10 + S[0] - '0';
                    answer |= y % 8 == 0;
                }
            }
            else
            {
                var x8 = Enumerable.Range(100, 900).Where(x => x % 8 == 0).ToArray();
                var count = new int[10];
                for (var i = 0; i < S.Length; i++) count[S[i] - '0']++;
                foreach (var x in x8)
                {
                    var ok = true;
                    var inCount = new int[10];
                    foreach (var c in x.ToString()) inCount[c - '0']++;
                    for (var i = 0; i < 10; i++) ok &= inCount[i] <= count[i];
                    answer |= ok;
                    if (answer) break;
                }
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }

    public static partial class EnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> source, int count)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            IEnumerable<IEnumerable<T>> Inner()
            {
                var items = source.ToArray();
                if (count <= 0 || items.Length < count) throw new ArgumentOutOfRangeException(nameof(count));
                var idx = 0;
                var ret = new T[count];
                foreach (var x in Permutation(items.Length, count))
                {
                    ret[idx++] = items[x];
                    if (idx == count) yield return ret;
                    idx %= count;
                }
            }
            return Inner();
        }
        private static IEnumerable<int> Permutation(int n, int r)
        {
            var items = new int[r];
            var used = new bool[n];
            IEnumerable<int> Inner(int step = 0)
            {
                if (step >= r)
                {
                    foreach (var x in items) yield return x;
                    yield break;
                }
                for (var i = 0; i < n; i++)
                {
                    if (used[i]) continue;
                    used[i] = true;
                    items[step] = i;
                    foreach (var x in Inner(step + 1)) yield return x;
                    used[i] = false;
                }
            }
            return Inner();
        }
    }
}
