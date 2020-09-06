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
            var b = Console.ReadLine();
            var pair = "";
            switch (b)
            {
                case "A": pair = "T"; break;
                case "T": pair = "A"; break;
                case "C": pair = "G"; break;
                case "G": pair = "C"; break;
            }
            Console.WriteLine(pair);
        }
    }
}
