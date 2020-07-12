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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Console.WriteLine(ABC[2] >= ABC[0] && ABC[2] <= ABC[1] ? "Yes" : "No");
        }
    }
}
