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
            var NAB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, A, B) = (NAB[0], NAB[1], NAB[2]);
            var H = new long[N].Select(x => x = long.Parse(Console.ReadLine())).ToArray();
            var answer = 0;
            Console.WriteLine(answer);
        }
    }
}
