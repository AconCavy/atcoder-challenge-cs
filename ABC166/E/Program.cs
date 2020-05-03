using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E
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
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse);
            var count = 0L;
            var reduced = ai.Where(x => x < ai.Count()).ToArray();
            for (var i = 0; i < reduced.Length - 1; i++)
            {
                if (reduced[i] > reduced.Length - i - 1) continue;
                for (var j = i + 1; j < reduced.Length; j++)
                {
                    if (Math.Abs(i - j) == reduced[i] + reduced[j]) count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
