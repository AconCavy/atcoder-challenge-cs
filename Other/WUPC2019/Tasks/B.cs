using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var G = new int[H][];
            var ok = false;
            var zero = 0;
            var max = 0;
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.ScanEnumerable<int>().ToArray();
                for (var j = 0; j < W; j++)
                {
                    ok |= G[i][j] == 5;
                    if (G[i][j] == 0) zero++;
                    max = Math.Max(max, G[i][j]);
                }
            }

            if (!ok)
            {
                if (zero == H * W) Console.WriteLine("Yes 0");
                else Console.WriteLine("No");
                return;
            }

            int To5(int max)
            {
                return max switch
                {
                    6 => 1,
                    7 => 1,
                    8 => 2,
                    9 => 3,
                    _ => 0
                };
            }

            var answer = 1;

            if (H == 1 || W == 1)
            {
                var line = new int[Math.Max(H, W)];
                if (H == 1)
                {
                    for (var i = 0; i < W; i++) line[i] = G[0][i];
                }
                else
                {
                    for (var i = 0; i < H; i++) line[i] = G[i][0];
                }

                var idx = 0;
                var min = 100;
                while (true)
                {
                    var sum = 0;
                    while (idx < line.Length && line[idx] != 5) idx++;
                    if (idx == line.Length) break;
                    max = 0;
                    for (var i = 0; i < idx; i++) max = Math.Max(max, line[i]);
                    sum += To5(max);

                    max = 0;
                    for (var i = idx + 1; i < line.Length; i++) max = Math.Max(max, line[i]);
                    sum += To5(max);

                    min = Math.Min(min, sum);
                    idx++;
                }

                answer += min;
            }
            else
            {
                answer += To5(max);
            }

            Console.WriteLine($"Yes {answer}");
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
