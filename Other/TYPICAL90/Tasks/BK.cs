using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class BK
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
            var (H, W) = Scanner.Scan<int, int>();
            var P = new int[H][];
            for (var i = 0; i < H; i++)
            {
                P[i] = Scanner.ScanEnumerable<int>().ToArray();
            }

            var answer = 0;
            for (var i = 1; i < 1 << H; i++)
            {
                var num = new int[W];
                var count = 0;
                for (var j = 0; j < H; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        count++;
                        for (var k = 0; k < W; k++)
                        {
                            if (num[k] == 0) num[k] = P[j][k];
                            else if (num[k] != P[j][k]) num[k] = -1;
                        }
                    }
                }

                var dict = new Dictionary<int, int>();
                for (var j = 0; j < W; j++)
                {
                    if (!dict.ContainsKey(num[j])) dict[num[j]] = 0;
                    dict[num[j]] += count;
                }

                foreach (var (k, v) in dict)
                {
                    if (k <= 0) continue;
                    answer = Math.Max(answer, v);
                }
            }

            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
