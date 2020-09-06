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
            var nmq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nmq[0];
            var m = nmq[1];
            var q = nmq[2];
            var l = new int[n];
            var r = new int[n];
            for (var i = 0; i < m; i++)
            {
                var lr = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                l[i] = lr[0];
                r[i] = lr[1];
            }
        }
    }
}
