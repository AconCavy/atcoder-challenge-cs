using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace B
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
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var answer = 0;
            while (true)
            {
                var ok = true;
                for (var i = 0; i < A.Length; i++)
                {
                    if (A[i] % 2 == 1)
                    {
                        ok = false;
                        break;
                    }
                    A[i] /= 2;
                }
                if (ok) answer++;
                else break;
            }
            Console.WriteLine(answer);
        }
    }
}
