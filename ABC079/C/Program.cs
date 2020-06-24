using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var ABCD = Console.ReadLine();
            for (var bit = 0; bit < (1 << 3); bit++)
            {
                var sum = ABCD[0] - '0';
                var answer = $"{ABCD[0]}";
                for (var i = 0; i < ABCD.Length - 1; i++)
                {
                    if (((bit >> i) & 1) == 1)
                    {
                        sum += ABCD[i + 1] - '0';
                        answer += $"+{ABCD[i + 1]}";
                    }
                    else
                    {
                        sum -= ABCD[i + 1] - '0';
                        answer += $"-{ABCD[i + 1]}";
                    }
                }
                if (sum == 7)
                {
                    Console.WriteLine(answer + "=7");
                    return;
                }
            }
        }
    }
}
