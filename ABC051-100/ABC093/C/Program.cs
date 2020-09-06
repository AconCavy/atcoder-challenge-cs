using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var answer = 0;
            Array.Sort(ABC);
            var left = (ABC[2] - ABC[0]) / 2;
            var mid = (ABC[2] - ABC[1]) / 2;
            answer = left + mid;
            ABC[0] += 2 * left;
            ABC[1] += 2 * mid;
            if (ABC[0] == ABC[1] && ABC[1] == ABC[2])
            {
                Console.WriteLine(answer);
                return;
            }
            Array.Sort(ABC);
            answer += ABC[0] == ABC[1] ? 1 : 2;
            Console.WriteLine(answer);
        }
    }
}
