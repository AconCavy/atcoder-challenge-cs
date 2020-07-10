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
            var S = Console.ReadLine();
            var ok = true;
            var hash = new HashSet<char>();
            for (var i = 0; i < S.Length; i++)
            {
                if (hash.Contains(S[i])) ok = false;
                hash.Add(S[i]);
            }
            Console.WriteLine(ok ? "yes" : "no");
        }
    }
}
