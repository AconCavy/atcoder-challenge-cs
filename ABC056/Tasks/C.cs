using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var current = 0;
            var t = 0;
            while (current < X)
            {
                current += ++t;
            }

            Console.WriteLine(t);
        }
    }
}
