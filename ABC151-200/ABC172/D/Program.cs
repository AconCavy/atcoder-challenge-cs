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
            var answer = 0L;
            for (var i = 1; i <= N; i++)
            {
                long r = N / i;
                answer += (r * (r + 1) / 2) * i;
            }
            Console.WriteLine(answer);
        }
    }
}
