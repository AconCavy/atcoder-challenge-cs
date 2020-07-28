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
            var N = S.Length - 1;
            var answer = 0L;
            for (var bit = 0; bit < 1 << N; bit++)
            {
                var current = 0L;
                var localBit = 0;
                for (var i = 0; i <= N; i++)
                {
                    current += (S[N - i] - '0') * (long)Math.Pow(10, localBit++);
                    if ((bit >> i & 1) == 1) localBit = 0;
                }
                answer += current;
            }

            Console.WriteLine(answer);
        }
    }
}
