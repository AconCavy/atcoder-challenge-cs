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
            var K = int.Parse(Console.ReadLine());
            var x = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;
            for (var i = 0; i < x.Length; i++)
            {
                answer += Math.Min(x[i], K - x[i]) * 2;
            }
            Console.WriteLine(answer);
        }
    }
}
