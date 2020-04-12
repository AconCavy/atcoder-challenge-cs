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
            var n = Console.ReadLine();
            var seven = n[0] == '7' || n[1] == '7' || n[2] == '7';
            Console.WriteLine(seven ? "Yes" : "No");
        }
    }
}
