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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NK[0];
            var K = NK[1];

            var answer = A;
            for (var i = 0; i < K; i++)
            {
                var tmp = new int[N + 1];
                for (var j = 0; j < answer.Length; j++)
                {
                    tmp[Math.Max(0, j - answer[j])]++;
                    tmp[Math.Min(N, j + answer[j] + 1)]--;
                }
                for (var j = 0; j < answer.Length; j++)
                {
                    tmp[j + 1] += tmp[j];
                }

                var isValid = true;
                for (var j = 0; j < answer.Length; j++)
                {
                    answer[j] = tmp[j];
                    if (answer[j] != N) isValid = false;
                }
                if (isValid) break;
            }

            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
