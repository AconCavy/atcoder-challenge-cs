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
            var pi = new int[n];
            for (var i = 0; i < n; i++)
            {
                pi[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(pi);
            pi[n - 1] /= 2;
            Console.WriteLine(pi.Sum());
        }
    }
}
