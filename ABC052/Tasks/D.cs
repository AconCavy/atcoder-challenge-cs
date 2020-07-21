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
            var NAB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, A, B) = (NAB[0], NAB[1], NAB[2]);
            var X = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0L;
            for (var i = 1; i < N; i++)
            {
                answer += Math.Min((X[i] - X[i - 1]) * A, B);
            }
            Console.WriteLine(answer);
        }
    }
}
