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
            var nmc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var bi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            for (var i = 0; i < nmc[0]; i++)
            {
                var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var sum = 0;
                for (var j = 0; j < ai.Length; j++)
                {
                    sum += ai[j] * bi[j];
                }
                sum += nmc[2];
                if (sum > 0) count++;
            }
            Console.WriteLine(count);
        }
    }
}
