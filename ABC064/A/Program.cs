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
            var RGB = int.Parse(Console.ReadLine().Replace(" ", ""));
            Console.WriteLine(RGB % 4 == 0 ? "YES" : "NO");

        }
    }
}
