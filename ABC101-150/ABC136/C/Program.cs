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
            var n = int.Parse(Console.ReadLine());
            var hi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var can = true;
            for (var i = hi.Length - 1; i > 0; i--)
            {
                if (hi[i] >= hi[i - 1]) continue;
                if (hi[i - 1] - hi[i] == 1)
                {
                    hi[i - 1]--;
                }
                else
                {
                    can = false;
                    break;
                }
            }

            Console.WriteLine(can ? "Yes" : "No");
        }
    }
}
