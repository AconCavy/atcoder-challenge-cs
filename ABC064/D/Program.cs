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
            var N = int.Parse(Console.ReadLine());
            var S = Console.ReadLine();
            var answer = S;
            var count = 0;
            for (var i = 0; i < S.Length; i++)
            {
                if (S[i] == '(') count++;
                else count--;
                if (count < 0)
                {
                    answer = "(" + answer;
                    count++;
                }
            }
            for (var i = 0; i < Math.Max(0, count); i++)
            {
                answer += ")";
            }

            Console.WriteLine(answer);
        }
    }
}
