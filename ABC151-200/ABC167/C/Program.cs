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
            var nmx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var query = new int[nmx[0]][];
            var result = long.MaxValue;
            for (var i = 0; i < nmx[0]; i++)
            {
                query[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }

            for (var bit = 0; bit < (1 << query.Length); bit++)
            {
                var scores = new int[nmx[1] + 1];
                for (var i = 0; i < nmx[0]; i++)
                {
                    if ((bit & (1 << i)) == 0) continue;
                    for (var j = 0; j < scores.Length; j++)
                    {
                        scores[j] += query[i][j];
                    };
                }

                var isValid = true;
                for (var i = 1; i < scores.Length; i++)
                {
                    if (scores[i] < nmx[2])
                    {
                        isValid = false;
                        break;
                    }
                }
                if (isValid) result = Math.Min(scores[0], result);
            }

            Console.WriteLine(result < long.MaxValue ? result : -1);
        }
    }
}
