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
            var L = new long[N + 1];
            L[0] = 2;
            L[1] = 1;
            for (var i = 2; i < L.Length; i++)
            {
                L[i] = L[i - 1] + L[i - 2];
            }
            Console.WriteLine(L[N]);
        }
    }
}
