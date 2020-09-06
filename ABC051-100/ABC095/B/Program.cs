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
            var nx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nx[0];
            var x = nx[1];
            var min = x;
            for (var i = 0; i < n; i++)
            {
                var m = int.Parse(Console.ReadLine());
                x -= m;
                min = Math.Min(min, m);
            }
            Console.WriteLine(n + x / min);
        }
    }
}
