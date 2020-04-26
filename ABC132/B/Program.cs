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
            var pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            for (var i = 1; i < pi.Length - 1; i++)
            {
                if ((pi[i - 1] < pi[i] && pi[i] < pi[i + 1]) ||
                (pi[i - 1] > pi[i] && pi[i] > pi[i + 1]))
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
