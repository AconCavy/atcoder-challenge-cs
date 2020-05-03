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
            var n = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var sum = 0L;
            var min = (long)Math.Pow(10, 9);
            var minIndex = 0;
            var minusCount = 0;
            for (var i = 0; i < ai.Length; i++)
            {
                if (ai[i] < 0) minusCount++;
                ai[i] = Math.Abs(ai[i]);
                if (ai[i] < min)
                {
                    min = ai[i];
                    minIndex = i;
                }
                sum += ai[i];
            }
            if (minusCount % 2 == 1) sum -= 2 * ai[minIndex];
            Console.WriteLine(sum);
        }
    }
}
