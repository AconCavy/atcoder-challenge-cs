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
            var nk = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var aggregated = new long[nk[0] + 1];
            var count = 0L;
            for (var i = 1; i < aggregated.Length; i++)
            {
                aggregated[i] = ai[i - 1] + aggregated[i - 1];
            }

            var threthold = 0;
            for (var i = 0; i < aggregated.Length; i++)
            {
                if (aggregated[i] >= nk[1])
                {
                    threthold = i;
                    break;
                }
            }

            for (var i = 0; i < aggregated.Length; i++)
            {
                while (threthold < aggregated.Length)
                {
                    if (aggregated[threthold] - aggregated[i] >= nk[1])
                    {
                        count += aggregated.Length - threthold;
                        break;
                    }
                    threthold++;
                }
            }

            // var sum = 0L;
            // for (int l = 0, r = 0; l < ai.Length; l++)
            // {
            //     while (sum < nk[1])
            //     {
            //         if (r == ai.Length) break;
            //         sum += ai[r];
            //         r++;
            //     }
            //     if (sum < nk[1]) break;
            //     count += ai.Length - r + 1;
            //     sum -= ai[l];
            // }

            Console.WriteLine(count);
        }
    }
}
