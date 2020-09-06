using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
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
            var NW = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, W) = (NW[0], NW[1]);
            var w = new long[N];
            var v = new long[N];
            for (var i = 0; i < N; i++)
            {
                var wv = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                w[i] = wv[0];
                v[i] = wv[1];
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
    }
}
