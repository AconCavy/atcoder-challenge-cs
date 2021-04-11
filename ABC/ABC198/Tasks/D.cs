using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var S1 = Scanner.Scan<string>();
            var S2 = Scanner.Scan<string>();
            var S3 = Scanner.Scan<string>();

            var s1 = S1.Select(x => x - 'a').ToArray();
            var s2 = S2.Select(x => x - 'a').ToArray();
            var s3 = S3.Select(x => x - 'a').ToArray();

            var used = new bool[26];
            foreach (var c in s1) used[c] = true;
            foreach (var c in s2) used[c] = true;
            foreach (var c in s3) used[c] = true;
            var count = used.Count(x => x);
            var idx = new List<int>();
            for (var i = 0; i < 26; i++)
            {
                if (used[i]) idx.Add(i);
            }

            if (count > 10)
            {
                Console.WriteLine("UNSOLVABLE");
                return;
            }

            foreach (var perm in Enumerable.Range(0, 10).Permute(count))
            {
                var p = perm.ToArray();
                var map = new int[26];
                for (var i = 0; i < count; i++) map[idx[i]] = p[i];
                if (map[s3[0]] == 0 || map[s2[0]] == 0 || map[s1[0]] == 0) continue;
                var (n1, n2, n3) = (0L, 0L, 0L);
                foreach (var c in s1) n1 = n1 * 10 + map[c];
                foreach (var c in s2) n2 = n2 * 10 + map[c];
                foreach (var c in s3) n3 = n3 * 10 + map[c];
                if (n1 + n2 == n3)
                {
                    Console.WriteLine(n1);
                    Console.WriteLine(n2);
                    Console.WriteLine(n3);
                    return;
                }
            }

            Console.WriteLine("UNSOLVABLE");
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
