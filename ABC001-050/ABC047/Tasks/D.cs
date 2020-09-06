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
            var NT = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, T) = (NT[0], NT[1]);
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var B = new int[N];
            var max = A[N - 1];
            var answer = 0;
            for (var i = N - 2; i >= 0; i--)
            {
                if (A[i] > max) max = A[i];
                B[i] = max;
            }

            var maxDiff = 0;
            for (var i = 0; i < A.Length - 1; i++)
            {
                var diff = B[i] - A[i];
                if (diff == maxDiff) answer++;
                else if (diff > maxDiff)
                {
                    maxDiff = diff;
                    answer = 1;
                }
            }

            Console.WriteLine(answer);
        }
    }
}
