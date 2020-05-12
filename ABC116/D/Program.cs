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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sushis = new Tuple<long, long>[nk[0]];
            for (var i = 0; i < sushis.Length; i++)
            {
                var sushi = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                sushis[i] = new Tuple<long, long>(sushi[0], sushi[1]);
            }

            // var dp = new long[nk[1] + 1];
            // var orders = sushis.OrderBy(x => x.Item2).ToList();
            // var types = new Dictionary<long, long>();
            // for (var i = 1; i < dp.Length; i++)
            // {
            //     long tCount = types.Keys.Count();
            //     long max = 0;
            //     var maxIndex = 0;
            //     for (var j = 0; j < orders.Count; j++)
            //     {
            //         var sushi = orders[j];
            //         var d = sushi.Item2;
            //         var t = tCount + (types.ContainsKey(sushi.Item1) ? 0L : 1L);
            //         var score = d + t * t;
            //         if (score > max)
            //         {
            //             max = score;
            //             maxIndex = j;
            //         }
            //     }
            //     var tmp = orders[maxIndex];
            //     dp[i] = dp[i - 1] + tmp.Item2;
            //     if (!types.ContainsKey(tmp.Item1)) types.Add(tmp.Item1, 1L);
            //     orders.RemoveAt(maxIndex);
            // }
            // Console.WriteLine(string.Join(", ", types.Values));
            // var typeBonus = (long)types.Keys.Count() * (long)types.Keys.Count();
            // Console.WriteLine(dp[dp.Length - 1] + typeBonus);
        }
    }
}
