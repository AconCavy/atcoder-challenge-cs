using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var T = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var V = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            double answer = 0;
            var t = 1;
            double v = 0;
            var i = 0;
            while (t <= T[N - 1])
            {
                if (i == N - 1 || v > V[i + 1])
                {
                    if (t == T[i] - v)
                    {
                        answer += v - 0.5;
                        v--;
                    }
                    else
                    {
                        if (v < V[i])
                        {
                            v++;
                            answer += v - 0.5;
                        }
                        else
                        {
                            answer += v;
                        }
                    }
                }
                else
                {
                    if (v < V[i])
                    {
                        v++;
                        answer += v - 0.5;
                    }
                    else
                    {
                        answer += v;
                    }
                }

                Console.WriteLine($"t:{t}, {answer}");
                t++;
                if (t == T[i]) i++;
            }

            Console.WriteLine(answer);
        }
    }
}
