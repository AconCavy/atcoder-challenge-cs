using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var x = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            for (var i = 0; i < x.Length; i++)
            {
                if (x[i] == 0)
                {
                    Console.WriteLine(i + 1);
                    return;
                }
            }
        }
    }
}
