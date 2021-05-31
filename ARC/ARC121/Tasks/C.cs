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

                int GetIdx(int x)
                {
                    var idx = 0;
                    while (P[idx] != x) idx++;
                    return idx;
                }

                void Swap(int idx)
                {
                    (P[idx], P[idx + 1]) = (P[idx + 1], P[idx]);
                    answer.Add(idx + 1);
                    k ^= 1;
                }

                for (var x = N; x >= 5; x--)
                {
                    var idx = GetIdx(x);
                    if (idx % 2 != k)
                    {
                        if (idx == 0) Swap(1);
                        else if (idx == 1) Swap(2);
                        else if (idx == 2) Swap(3);
                        else Swap(k);
                    }

                    for (var i = idx; i + 1 < x; i++)
                    {
                        Swap(i);
                    }
                }

                if (N >= 4)
                {
                    var idx = GetIdx(4);
                    if (idx % 2 != k)
                    {
                        if (idx == 0 || idx == 1)
                        {
                            Swap(idx % 2 + 1);
                            for (var i = idx; i + 1 < 4; i++)
                            {
                                Swap(i);
                            }
                        }
                        else if (idx == 2)
                        {
                            Swap(1);
                            Swap(2);
                            Swap(1);
                            Swap(2);
                        }
                    }
                    else
                    {
                        for (var i = idx; i + 1 < 4; i++)
                        {
                            Swap(i);
                        }
                    }
                }

                while ((P[0], P[1]) != (1, 2))
                {
                    Swap(k);
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
