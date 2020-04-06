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
            var n = int.Parse(Console.ReadLine());
            var red = new List<int>();
            var blue = new List<int>();

            for (var i = 0; i < n; i++)
            {
                var xc = Console.ReadLine().Trim().Split(' ');
                if (xc[1] == "R") red.Add(int.Parse(xc[0]));
                else blue.Add(int.Parse(xc[0]));
            }
            red.Sort();
            blue.Sort();
            foreach (var ball in red) Console.WriteLine(ball);
            foreach (var ball in blue) Console.WriteLine(ball);
        }
    }
}
