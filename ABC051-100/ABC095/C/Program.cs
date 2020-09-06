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
            var abcxy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var a = abcxy[0];
            var b = abcxy[1];
            var c = abcxy[2];
            var x = abcxy[3];
            var y = abcxy[4];

            var min = Math.Min(x, y);
            var max = Math.Max(x, y);
            var minA = Math.Min(a, 2 * c);
            var minB = Math.Min(b, 2 * c);
            var answer = 0L;
            answer = a * x + b * y;
            answer = Math.Min(answer, 2 * c * max);
            answer = Math.Min(answer, 2 * c * min + minA * (x - min) + minB * (y - min));

            Console.WriteLine(answer);
        }
    }
}
