using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class A
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
            var X = int.Parse(Console.ReadLine());
            var c = new int[] { 0, 0, 8, 7, 6, 5, 4, 3, 2, 1 };
            Console.WriteLine(c[X / 200]);
        }
    }
}
