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
            var n = long.Parse(Console.ReadLine());
            var capacities = new long[5];
            for (var i = 0; i < capacities.Length; i++)
            {
                capacities[i] = long.Parse(Console.ReadLine());
            }
            var time = 0L;
            // var current = new long[6];
            // current[0] = n;
            // while (current[5] < n)
            // {
            //     for (var i = current.Length - 1; i > 0; i--)
            //     {
            //         var move = Math.Min(current[i - 1], capacities[i - 1]);
            //         current[i] += move;
            //         current[i - 1] -= move;
            //     }
            //     time++;
            // }
            var min = capacities.Min();
            time = (long)Math.Ceiling(n / (double)min) + 4;

            Console.WriteLine(time);
        }
    }
}
