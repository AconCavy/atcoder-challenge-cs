using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var (N, K) = Scanner.Scan<int, int>();
            var T = new long[N].Select(_ => Scanner.ScanEnumerable<long>().ToArray()).ToArray();
            var answer = 0;
            foreach (var permutation in Enumerable.Range(1, N - 1).Permute(N - 1))
            {
                var sum = 0L;
                var prev = 0;
                foreach (var x in permutation)
                {
                    sum += T[prev][x];
                    prev = x;
                }
                if (sum + T[prev][0] == K) answer++;
            }
            Console.WriteLine(answer);
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
