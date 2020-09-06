using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var P = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0;

            for (var i = 0; i < P.Length - 1; i++)
            {
                if (P[i] == i + 1 && P[i + 1] == i + 2)
                {
                    answer++;
                    (P[i], P[i + 1]) = (P[i + 1], P[i]);
                }
            }

            for (var i = 0; i < P.Length - 1; i++)
            {
                if (P[i] == i + 1 || P[i + 1] == i + 2)
                {
                    answer++;
                    (P[i], P[i + 1]) = (P[i + 1], P[i]);
                }
            }
            Console.WriteLine(answer);
        }
    }
}
