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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0L;
            var leaves = new long[ai.Length];

            for (var i = ai.Length - 2; i >= 0; i--)
            {
                leaves[i] = leaves[i + 1] + ai[i + 1];
            }

            var count = 1L;
            for (var i = 0; i < ai.Length; i++)
            {
                answer += count;
                count -= ai[i];
                if (count < 0)
                {
                    Console.WriteLine(-1);
                    return;
                }
                count = Math.Min(count * 2, leaves[i]);
            }

            Console.WriteLine(answer);
        }
    }
}
