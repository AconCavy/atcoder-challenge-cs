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
            var XY = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var X = XY[0];
            var Y = XY[1];
            var answer = false;

            for (var i = 0; i <= X; i++)
            {
                var turu = i;
                var kame = X - i;
                if (2 * turu + 4 * kame == Y) answer = true;
            }
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
