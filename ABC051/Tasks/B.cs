using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var KS = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (K, S) = (KS[0], KS[1]);
            var answer = 0;
            for (var x = 0; x <= K; x++)
            {
                for (var y = 0; y <= K; y++)
                {
                    var z = S - x - y;
                    if (z >= 0 && z <= K) answer++;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
