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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sum = ai.Sum();
            var canSelect = false;
            var count = 0;
            for (var i = 0; i < ai.Length; i++)
            {
                if (ai[i] * 4 * nm[1] >= sum)
                {
                    count++;
                }
            }
            if (count >= nm[1]) canSelect = true;
            Console.WriteLine(canSelect ? "Yes" : "No");
        }
    }
}
