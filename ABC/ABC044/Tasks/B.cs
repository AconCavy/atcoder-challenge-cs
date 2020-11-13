using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var W = Console.ReadLine();
            var dict = new Dictionary<char, int>();
            for (var i = 0; i < W.Length; i++)
            {
                if (!dict.ContainsKey(W[i])) dict[W[i]] = 0;
                dict[W[i]]++;
            }
            var answer = true;
            foreach (var x in dict.Values)
            {
                if (x % 2 == 1) answer = false;
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
