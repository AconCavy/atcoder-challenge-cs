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
            var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (A, B, C) = (ABC[0], ABC[1], ABC[2]);
            var n = A;
            var answer = false;
            while (n <= A * B)
            {
                if (n % B == C) answer = true;
                n += A;
            }

            Console.WriteLine(answer ? "YES" : "NO");
        }
    }
}
