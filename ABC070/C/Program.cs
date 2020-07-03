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
            var T = new long[N].Select(x => x = long.Parse(Console.ReadLine())).ToArray();
            var answer = 1L;
            for (var i = 0; i < N; i++)
            {
                answer = LCM(answer, T[i]);
            }
            Console.WriteLine(answer);
        }

        static long LCM(long a, long b)
        {
            var (min, max) = a >= b ? (a, b) : (b, a);
            return min * (max / GCD(min, max));
        }
        static long GCD(long a, long b) => b == 0 ? a : GCD(b, a % b);
    }
}