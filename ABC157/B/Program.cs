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
            var bingo = new int[9];
            for (var i = 0; i < 3; i++)
            {
                var vals = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var step = 3 * i;
                bingo[step] = vals[0];
                bingo[step + 1] = vals[1];
                bingo[step + 2] = vals[2];
            }

            var result = new bool[9];
            var n = int.Parse(Console.ReadLine());
            for (var i = 0; i < n; i++)
            {
                var val = int.Parse(Console.ReadLine());
                for (var j = 0; j < 9; j++)
                {
                    if (val == bingo[j])
                    {
                        result[j] = true;
                        break;
                    }
                }
            }

            var isBingo = false;
            for (var i = 0; i < 3; i++)
            {
                var step = 3 * i;
                if (result[step] && result[step + 1] && result[step + 2])
                {
                    isBingo = true;
                    break;
                }
                if (result[i] && result[i + 3] && result[i + 6])
                {
                    isBingo = true;
                    break;
                }
            }
            if (result[4])
            {
                if ((result[0] && result[8]) || (result[2] && result[6]))
                {
                    isBingo = true;
                }
            }
            Console.WriteLine(isBingo ? "Yes" : "No");
        }
    }
}
