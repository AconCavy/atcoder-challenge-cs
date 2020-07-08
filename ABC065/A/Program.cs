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
            var XAB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var X = XAB[0];
            var A = XAB[1];
            var B = XAB[2];
            var delicious = B - A <= 0;
            var safe = B - A <= X;
            Console.WriteLine(delicious ? "delicious" : (safe ? "safe" : "dangerous"));
        }
    }
}
