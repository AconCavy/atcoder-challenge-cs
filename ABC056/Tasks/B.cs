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
            var WAB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (W, A, B) = (WAB[0], WAB[1], WAB[2]);
            Console.WriteLine(Math.Max(0, Math.Max(B - (A + W), A - (B + W))));
        }
    }
}
