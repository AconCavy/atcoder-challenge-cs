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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (A, B, C) = (ABC[0], ABC[1], ABC[2]);
            var K = int.Parse(Console.ReadLine());

            for (var i = 0; i < K; i++)
            {
                if (B <= A) B *= 2;
                else if (C <= B) C *= 2;
            }

            var answer = A < B && B < C;
            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
