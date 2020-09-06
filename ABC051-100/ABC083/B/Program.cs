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
            var NAB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NAB[0];
            var A = NAB[1];
            var B = NAB[2];
            var answer = 0;
            for (var i = 1; i <= N; i++)
            {
                var val = i.ToString().Sum(x => x - '0');
                if (A <= val && val <= B) answer += i;
            }
            Console.WriteLine(answer);
        }
    }
}
