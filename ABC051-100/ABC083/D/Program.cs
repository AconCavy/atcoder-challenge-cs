using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var answer = S.Length;
            for (var i = 0; i < S.Length - 1; i++)
            {
                if (S[i] == S[i + 1]) continue;
                answer = Math.Min(answer, Math.Max(i + 1, S.Length - i - 1));
            }
            Console.WriteLine(answer);
        }
    }
}
