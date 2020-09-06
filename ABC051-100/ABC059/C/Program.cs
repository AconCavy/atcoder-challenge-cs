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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = (long)1e18;
            var t = 1;
            for (var k = 0; k < 2; k++)
            {
                t ^= 1;
                var step = 0L;
                var sum = 0L;
                for (var i = 0; i < N; i++)
                {
                    sum += A[i];

                    if (i % 2 == t)
                    {
                        if (sum <= 0)
                        {
                            step += 1 - sum;
                            sum = 1;
                        }
                    }
                    else
                    {
                        if (sum >= 0)
                        {
                            step += 1 + sum;
                            sum = -1;
                        }
                    }
                }
                answer = Math.Min(answer, step);
            }

            Console.WriteLine(answer);
        }
    }
}
