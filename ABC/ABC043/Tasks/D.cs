using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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
            var dict = new Dictionary<char, int>();
            var l = -1;
            var r = -1;
            for (var i = 0; i < S.Length - 1; i++)
            {
                if (S[i] == S[i + 1])
                {
                    l = i + 1;
                    r = i + 2;
                    break;
                }

                if (i + 2 < S.Length && S[i] == S[i + 2])
                {
                    l = i + 1;
                    r = i + 3;
                    break;
                }
            }

            Console.WriteLine($"{l} {r}");
        }
    }
}
