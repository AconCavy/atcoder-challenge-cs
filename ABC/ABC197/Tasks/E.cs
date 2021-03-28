using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
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
            var N = Scanner.Scan<int>();
            var B = new List<int>[N].Select(_ => new List<int>()).ToArray();
            for (var i = 0; i < N; i++)
            {
                var (x, c) = Scanner.Scan<int, int>();
                B[c - 1].Add(x);
            }

            const int inf = (int)1e9;
            var (l, r) = (0, 0);
            var (cl, cr) = (0L, 0L);
            for (var i = 0; i < N; i++)
            {
                if (!B[i].Any()) continue;

                var (min, max) = (inf, -inf);
                foreach (var x in B[i])
                {
                    min = Math.Min(min, x);
                    max = Math.Max(max, x);
                }


                var nr = Math.Min(cl + Math.Abs(l - min), cr + Math.Abs(r - min)) + max - min;
                var nl = Math.Min(cl + Math.Abs(l - max), cr + Math.Abs(r - max)) + max - min;

                (l, r) = (min, max);
                (cl, cr) = (nl, nr);
            }

            var answer = Math.Min(cl + Math.Abs(l), cr + Math.Abs(r));
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
}
