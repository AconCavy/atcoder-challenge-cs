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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var bi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var ci = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sum = 0;
            var previous = ai[0] - 1;
            for (var i = 0; i < ai.Length; i++)
            {
                var index = ai[i] - 1;
                sum += bi[index];
                if (previous == index - 1) sum += ci[index - 1];
                previous = index;
            }
            Console.WriteLine(sum);
        }
    }
}
