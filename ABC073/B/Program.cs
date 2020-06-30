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
            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                var lr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                answer += lr[1] - lr[0] + 1;
            }
            Console.WriteLine(answer);
        }
    }
}
