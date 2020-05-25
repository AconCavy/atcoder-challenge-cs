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
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            var prev = Console.ReadLine();
            dict[prev] = 1;
            for (var i = 1; i < n; i++)
            {
                var w = Console.ReadLine();
                if (dict.ContainsKey(w) || prev[prev.Length - 1] != w[0])
                {
                    Console.WriteLine("No");
                    return;
                }
                dict[w] = 1;
                prev = w;
            }
            Console.WriteLine("Yes");
        }
    }
}
