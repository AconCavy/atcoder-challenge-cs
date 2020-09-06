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
            var have = new bool[nk[0]];
            for (var i = 0; i < nk[1]; i++)
            {
                var d = int.Parse(Console.ReadLine());
                var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < ai.Length; j++)
                {
                    have[ai[j] - 1] = true;
                }
            }
            Console.WriteLine(have.Where(x => !x).Count());
        }
    }
}
