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
            var (D, G) = Scanner.Scan<int, int>();
            var P = new int[D];
            var C = new int[D];
            for (var i = 0; i < D; i++)
            {
                var (p, c) = Scanner.Scan<int, int>();
                P[i] = p;
                C[i] = c;
            }

            var answer = (int)1e9;

            for (var s = 0; s < 1 << D; s++)
            {
                var score = 0;
                var count = 0;
                var idx = -1;
                for (var b = 0; b < D; b++)
                {
                    if ((s >> b & 1) == 1)
                    {
                        score += 100 * (b + 1) * P[b] + C[b];
                        count += P[b];
                    }
                    else idx = b;
                }

                if (score < G)
                {
                    if (idx < 0) continue;
                    var maxScore = 100 * (idx + 1);
                    var p = (G - score + maxScore - 1) / maxScore;
                    if (p >= P[idx]) continue;
                    count += p;
                }

                answer = Math.Min(answer, count);
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
}
