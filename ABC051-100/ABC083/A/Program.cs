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
            var ABCD = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var left = ABCD[0] + ABCD[1];
            var right = ABCD[2] + ABCD[3];
            var answer = "Balanced";
            if (left > right) answer = "Left";
            if (right > left) answer = "Right";
            Console.WriteLine(answer);
        }
    }
}
