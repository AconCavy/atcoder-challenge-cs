using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var dg = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var d = dg[0];
            var g = dg[1];
            var pi = new int[d];
            var ci = new int[d];
            var answer = (int)1e9;
            for (var i = 0; i < d; i++)
            {
                var pc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                pi[i] = pc[0];
                ci[i] = pc[1];
            }

            for (var bit = 0; bit < (1 << d); bit++)
            {
                var score = 0;
                var num = 0;
                var maxIndex = 0;
                for (var i = 0; i < d; i++)
                {
                    if (((bit >> i) & 1) == 1)
                    {
                        score += 100 * (i + 1) * pi[i] + ci[i];
                        num += pi[i];
                    }
                    else
                    {
                        maxIndex = i;
                    }
                }

                if (score < g)
                {
                    var max = 100 * (maxIndex + 1);
                    var need = (g - score + max - 1) / max;
                    if (need >= pi[maxIndex]) continue;
                    num += need;
                }
                answer = Math.Min(answer, num);
            }
            Console.WriteLine(answer);
        }
    }
}
