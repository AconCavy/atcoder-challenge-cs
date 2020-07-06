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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NK[0];
            var K = NK[1];
            var L = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = L.OrderByDescending(x => x).Take(K).Sum();
            Console.WriteLine(answer);
        }
    }
}
