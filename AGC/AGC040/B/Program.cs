using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var n = int.Parse(Console.ReadLine());
            var lr = new Pair[n];
            for (var i = 0; i < n; i++)
            {
                var tmp = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                lr[i] = new Pair { L = tmp[0], R = tmp[1] };
            }
            lr = lr.OrderBy(x => x.L).ThenByDescending(x => x.R).ToArray();

            var answer = 0L;
            // var max = (1 << n) - 1;
            // for (var bit = 1; bit < max; bit++)
            // {
            //     if ((bit & max) > 0) continue;
            //     var left1 = 0L;
            //     var right1 = 1000000000L;
            //     var left2 = 0L;
            //     var right2 = 1000000000L;
            //     var sum = 0L;
            //     for (var i = 0; i < lr.Length; i++)
            //     {
            //         var index = lr.Length - 1 - i;
            //         if (((bit >> i) & 1) == 0)
            //         {
            //             left1 = Math.Max(left1, lr[index].L);
            //             right1 = Math.Min(right1, lr[index].R);
            //         }
            //         else
            //         {
            //             left2 = Math.Max(left2, lr[index].L);
            //             right2 = Math.Min(right2, lr[index].R);
            //         }
            //     }
            //     sum = right1 - left1 + right2 - left2 + 2;
            //     answer = Math.Max(answer, sum);
            // }
            Console.WriteLine(answer);
        }
    }

    public struct Pair
    {
        public int L { get; set; }
        public int R { get; set; }
    }
}
