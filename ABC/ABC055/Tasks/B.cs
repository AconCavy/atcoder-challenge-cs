using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var p = (int)1e9 + 7;
            var answer = 1L;
            for (var i = 1; i <= N; i++)
            {
                answer *= i;
                answer %= p;
            }
            Console.WriteLine(answer);
        }
    }
}
