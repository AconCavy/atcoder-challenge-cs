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
            var XY = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var X = XY[0];
            var Y = XY[1];
            var answer = 0;
            var tmp = X;
            while (tmp <= Y)
            {
                answer++;
                tmp *= 2;
            }
            Console.WriteLine(answer);
        }
    }
}
