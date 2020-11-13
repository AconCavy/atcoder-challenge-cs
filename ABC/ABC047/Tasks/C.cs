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
            var S = Console.ReadLine();
            var answer = 0;
            for (var i = 1; i < S.Length; i++)
            {
                if (S[i] != S[i - 1]) answer++;
            }
            Console.WriteLine(answer);
        }
    }
}
