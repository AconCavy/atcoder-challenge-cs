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
            var NK = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var N = NK[0];
            var K = NK[1];
            var answer = K == 0 ? -N : 0L;
            for (var i = 1; i <= N; i++)
            {
                var b = i;
                var a = Math.Max(b - K, 0);
                var div = N / b;
                var sub = N - b * div;
                answer += div * a + Math.Max(sub - K + 1, 0);
            }

            Console.WriteLine(answer);
        }
    }
}
