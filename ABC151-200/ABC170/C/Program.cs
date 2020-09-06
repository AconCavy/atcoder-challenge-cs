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
            var XN = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var X = XN[0];
            var N = XN[1];
            var pi = new int[N];
            if (N == 0)
            {
                var tmp = Console.ReadLine();
            }
            else
            {
                pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            if (N == 0)
            {
                Console.WriteLine(X);
                return;
            }

            var hash = new HashSet<int>();
            for (var i = 0; i < pi.Length; i++)
            {
                hash.Add(pi[i]);
            }
            var answer = 0;
            var d = 0;
            while (true)
            {
                var left = X - d;
                var right = X + d;
                if (!hash.Contains(left))
                {
                    answer = left;
                    break;
                }
                if (!hash.Contains(right))
                {
                    answer = right;
                    break;
                }
                d++;
            }

            Console.WriteLine(answer);
        }
    }
}
