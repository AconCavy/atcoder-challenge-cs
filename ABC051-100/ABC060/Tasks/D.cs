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
            var (N, W) = Scanner.Scan<int, int>();
            var w = new long[N];
            var v = new long[N];
            for (var i = 0; i < N; i++)
            {
                (w[i], v[i]) = Scanner.Scan<long, long>();
            }

            // var dp = (new long[2][]).Select(x => x = new long[W + 1]).ToArray();
            // var t = 1;
            // for (var i = 0; i < N; i++)
            // {
            //     t ^= 1;
            //     for (var j = 0; j <= W; j++)
            //     {
            //         if (j < w[i])
            //         {
            //             dp[t ^ 1][j] = dp[t][j];
            //         }
            //         else
            //         {
            //             dp[t ^ 1][j] = Math.Max(dp[t][j], dp[t][Math.Max(0, j - w[i])] + v[i]);
            //         }
            //     }
            // }
            // var answer = dp[t ^ 1][W];

            var dict = new Dictionary<long, List<long>>();
            var min = w[0];
            for (var i = 0; i < N; i++)
            {
                min = Math.Min(min, w[i]);
                if (dict.ContainsKey(w[i])) dict[w[i]].Add(v[i]);
                else dict[w[i]] = new List<long> { v[i] };
            }

            var w0v = CumulativeItems(dict[min].OrderByDescending(x => x)).ToArray();
            var w1v = dict.ContainsKey(min + 1) ? CumulativeItems(dict[min + 1].OrderByDescending(x => x)).ToArray() : new long[] { 0 };
            var w2v = dict.ContainsKey(min + 2) ? CumulativeItems(dict[min + 2].OrderByDescending(x => x)).ToArray() : new long[] { 0 };
            var w3v = dict.ContainsKey(min + 3) ? CumulativeItems(dict[min + 3].OrderByDescending(x => x)).ToArray() : new long[] { 0 };

            var answer = 0L;
            for (var i = 0; i < w0v.Length; i++)
            {
                for (var j = 0; j < w1v.Length; j++)
                {
                    for (var k = 0; k < w2v.Length; k++)
                    {
                        for (var l = 0; l < w3v.Length; l++)
                        {
                            var weight = i * min + j * (min + 1) + k * (min + 2) + l * (min + 3);
                            if (weight > W) continue;
                            var sum = w0v[i] + w1v[j] + w2v[k] + w3v[l];
                            answer = Math.Max(answer, sum);
                        }
                    }
                }
            }

            Console.WriteLine(answer);
        }

        public static IEnumerable<long> CumulativeItems(IEnumerable<long> items)
        {
            var arr = items.ToArray();
            var ret = new long[arr.Length + 1];
            for (var i = 0; i < arr.Length; i++) ret[i + 1] = arr[i] + ret[i];
            return ret;
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
