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
            var lr = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var min = (lr[0] % 2019 * lr[1] % 2019) % 2019;
            for (var i = lr[0]; i <= lr[1] - 1; i++)
            {
                for (var j = i + 1; j <= lr[1]; j++)
                {
                    min = Math.Min((i % 2019 * j % 2019) % 2019, min);
                    if (min == 0) break;
                }
                if (min == 0) break;
            }
            Console.WriteLine(min);
        }
    }
}
