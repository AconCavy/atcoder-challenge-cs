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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nk[0];
            var k = nk[1];
            var pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = n - k + 1;
            for (var i = 0; i < pi.Length - k; i++)
            {
                var max = 0;
                var min = 1000000000;
                var prev = pi[i];
                for (var j = i; j < i + k; j++)
                {
                    max = Math.Max(max, pi[j]);
                    min = Math.Min(min, pi[j]);
                    prev = pi[j];
                }
                if (min > (i > 0 ? pi[i] : -1) && max < pi[i + k]) answer--;
            }
            Console.WriteLine(answer);
        }
    }
}
