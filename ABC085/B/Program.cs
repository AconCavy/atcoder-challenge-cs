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
            var N = int.Parse(Console.ReadLine());
            var d = new int[N];
            for (var i = 0; i < N; i++)
            {
                d[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine(d.Distinct().Count());
        }
    }
}
