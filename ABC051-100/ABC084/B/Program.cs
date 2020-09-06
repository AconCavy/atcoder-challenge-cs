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
            var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = AB[0];
            var B = AB[1];
            var S = Console.ReadLine();
            var answer = true;
            for (var i = 0; i < S.Length; i++)
            {
                if (i == A)
                {
                    if (S[i] != '-') answer = false;
                }
                else
                {
                    if (S[i] == '-') answer = false;
                }
            }
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
