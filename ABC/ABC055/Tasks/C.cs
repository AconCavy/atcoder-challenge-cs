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
            var NM = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var answer = 0L;
            if (M / 2 <= N)
            {
                answer = M / 2;
            }
            else
            {
                answer = N;
                M -= N * 2;
                answer += M / 4;
            }

            Console.WriteLine(answer);
        }
    }
}
