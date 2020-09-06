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
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var boss = new int[n];
            for (var i = 0; i < ai.Length; i++)
            {
                boss[ai[i] - 1]++;
            }

            for (var i = 0; i < boss.Length; i++)
            {
                Console.WriteLine(boss[i]);
            }
        }
    }
}
