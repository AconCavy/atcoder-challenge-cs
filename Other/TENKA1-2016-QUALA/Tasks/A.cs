using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            const int N = 100;
            var answer = 0;
            for (var i = 1; i <= N; i++)
            {
                if(i % 3 != 0 && i % 5 != 0) answer += i;
            }
            Console.WriteLine(answer);
        }
    }
}
