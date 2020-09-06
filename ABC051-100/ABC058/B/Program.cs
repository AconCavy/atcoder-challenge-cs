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
            var T = Console.ReadLine();
            var answer = "";
            for (var i = 0; i < S.Length; i++)
            {
                answer += S[i];
                if (i < T.Length) answer += T[i];
            }
            Console.WriteLine(answer);
        }
    }
}
