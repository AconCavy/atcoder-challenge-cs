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
            var XY = Console.ReadLine().Replace(" ", "");
            var X = XY[0] - 'A';
            var Y = XY[1] - 'A';
            var answer = "=";
            if (X > Y) answer = ">";
            if (X < Y) answer = "<";
            Console.WriteLine(answer);
        }
    }
}
