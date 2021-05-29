using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var T = Scanner.Scan<int>();
            while (T-- > 0)
            {
                var N = Scanner.Scan<int>();
                var P = Scanner.ScanEnumerable<int>().ToArray();
                var answer = new List<int>();

                var k = 0;
                for (var x = N; x >= 3; x--)
                {
                    var idx = 0;
                    while (P[idx] != x) idx++;
                    if (idx % 2 != k % 2)
                    {
                        var a = k % 2;
                        (P[a], P[a + 1]) = (P[a + 1], P[a]);
                        answer.Add(a + 1);
                        k++;
                    }

                    for (var i = idx; i + 1 < x; i++)
                    {
                        (P[i], P[i + 1]) = (P[i + 1], P[i]);
                        answer.Add(i + 1);
                        k++;
                    }
                }

                if (N > 2)
                {
                    while ((P[0], P[1]) != (1, 2))
                    {
                        var a = k % 2;
                        (P[a], P[a + 1]) = (P[a + 1], P[a]);
                        answer.Add(a + 1);
                        k++;
                    }
                }

                Console.WriteLine(answer.Count);
                if (answer.Count == 0) Console.WriteLine();
                else Console.WriteLine(string.Join(" ", answer));
            }
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
