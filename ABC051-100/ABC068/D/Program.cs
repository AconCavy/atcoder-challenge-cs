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
            var K = long.Parse(Console.ReadLine());
            var N = 50;
            var answer = new long[N];
            var r = K % N;
            for (var i = 0; i < r; i++)
            {
                answer[i] = (N - 1) + (K / N) + 1;
            }
            for (var i = r; i < N; i++)
            {
                answer[i] = (N - 1 - r) + (K / N);
            }
            Console.WriteLine(N);
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
