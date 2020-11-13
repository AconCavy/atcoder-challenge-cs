using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var hwab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var h = hwab[0];
            var w = hwab[1];
            var a = hwab[2];
            var b = hwab[3];

            var answer = new int[h][].Select(x => new int[w]).ToArray();

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    answer[i][j] = (i < b) ^ (j < a) ? 1 : 0;
                }
            }

            for (var i = 0; i < answer.Length; i++)
            {
                Console.WriteLine(string.Join("", answer[i]));
            }
        }
    }
}
