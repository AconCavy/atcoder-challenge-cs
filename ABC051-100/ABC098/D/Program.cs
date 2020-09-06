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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = 0L;
            var sum = 0L;
            var xor = 0L;
            var l = 0;
            var r = 0;
            while (r < ai.Length)
            {
                sum += ai[r];
                xor ^= ai[r];
                if (sum == xor)
                {
                    answer += r - l + 1;
                }
                else
                {
                    while (sum != xor)
                    {
                        sum -= ai[l];
                        xor ^= ai[l];
                        l++;
                    }
                    answer += r - l + 1;
                }
                r++;
            }

            Console.WriteLine(answer);
        }
    }
}
