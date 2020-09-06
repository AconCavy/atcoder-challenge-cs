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
            var bi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var killSum = 0L;
            for (var i = 0; i < bi.Length; i++)
            {
                var kill = Math.Min(ai[i], bi[i]);
                killSum += kill;
                bi[i] -= kill;

                kill = Math.Min(ai[i + 1], bi[i]);
                killSum += kill;
                ai[i + 1] -= kill;
            }
            Console.WriteLine(killSum);
        }
    }
}
