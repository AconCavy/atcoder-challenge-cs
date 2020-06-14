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
            var N = int.Parse(Console.ReadLine());
            var S = new string[N];
            var MARCH = new long[5];
            var answer = 0L;
            for (var i = 0; i < S.Length; i++)
            {
                S[i] = Console.ReadLine();
                switch (S[i][0])
                {
                    case 'M': MARCH[0]++; break;
                    case 'A': MARCH[1]++; break;
                    case 'R': MARCH[2]++; break;
                    case 'C': MARCH[3]++; break;
                    case 'H': MARCH[4]++; break;
                }
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    for (var k = j + 1; k < 5; k++)
                    {
                        if (MARCH[i] > 0 && MARCH[j] > 0 && MARCH[k] > 0)
                        {
                            answer += MARCH[i] * MARCH[j] * MARCH[k];
                        }
                    }
                }
            }

            Console.WriteLine(answer);
        }
    }
}
