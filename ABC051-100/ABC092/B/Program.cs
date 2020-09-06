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
            var N = int.Parse(Console.ReadLine());
            var DX = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var D = DX[0];
            var X = DX[1];
            var A = new int[N].Select(x => int.Parse(Console.ReadLine())).ToArray();
            var answer = N + X + A.Sum(x => (D - 1) / x);
            Console.WriteLine(answer);
        }
    }
}
