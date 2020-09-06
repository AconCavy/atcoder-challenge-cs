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
            var LRd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (L, R, d) = (LRd[0], LRd[1], LRd[2]);
            var answer = 0;
            for (var i = L; i <= R; i++)
            {
                if (i % d == 0) answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
