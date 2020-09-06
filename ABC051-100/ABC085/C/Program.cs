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
            var NY = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NY[0];
            var Y = NY[1];
            var num10000 = Math.Max(Math.Min((Y / 10000), N), 0);

            while (num10000 >= 0)
            {
                var m = N - num10000;
                for (var i = 0; i <= m; i++)
                {
                    var num5000 = i;
                    var num1000 = m - num5000;
                    var y = 10000 * num10000 + 5000 * num5000 + 1000 * num1000;

                    if (y == Y)
                    {
                        Console.WriteLine($"{num10000} {num5000} {num1000}");
                        return;
                    }
                }

                num10000--;
            }

            Console.WriteLine("-1 -1 -1");
        }
    }
}
