using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace A
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
            var ABC = Console.ReadLine().Trim().Split(' ');
            var (A, B, C) = (ABC[0], ABC[1], ABC[2]);
            var ab = A[A.Length - 1] == B[0];
            var bc = B[B.Length - 1] == C[0];
            Console.WriteLine(ab && bc ? "YES" : "NO");
        }
    }
}
