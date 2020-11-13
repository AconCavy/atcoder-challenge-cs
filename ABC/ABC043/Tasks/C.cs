using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = (int)1e9 + 1;
            var ave = A.Average();
            var arr = new int[] { (int)Math.Floor(ave), (int)Math.Ceiling(ave) };
            foreach (var y in arr)
            {
                var sum = A.Sum(x => (x - y) * (x - y));
                answer = Math.Min(answer, sum);
            }

            Console.WriteLine(answer);
        }
    }
}
