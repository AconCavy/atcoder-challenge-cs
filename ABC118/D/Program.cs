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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var result = "";
            var score = new int[] { 0, 2, 5, 5, 4, 5, 6, 3, 7, 6 };
            var use = ai.Select(x => score[x]).OrderByDescending(x => x).ToArray();

            var dp = new int[nm[0] + 1];
            for (var i = 1; i < dp.Length; i++)
            {

            }
            Console.WriteLine(result);
        }
    }
}
