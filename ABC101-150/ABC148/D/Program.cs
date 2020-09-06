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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var number = 1;
            var count = 0;
            for (var i = 0; i < ai.Length; i++)
            {
                if (ai[i] != number)
                {
                    ai[i] = -1;
                    count++;
                    continue;
                }
                number++;
            }
            Console.WriteLine(ai.Where(x => x > 0).Count() != 0 ? count : -1);
        }
    }
}
