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
            var nkq = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            if (nkq[1] > nkq[2])
            {
                for (var i = 0; i < nkq[0]; i++)
                {
                    Console.WriteLine("Yes");
                }
                return;
            }

            var points = new int[nkq[0]];
            for (var i = 0; i < nkq[2]; i++)
            {
                var a = int.Parse(Console.ReadLine());
                points[a - 1]++;
            }

            for (var i = 0; i < points.Length; i++)
            {
                Console.WriteLine(points[i] > nkq[2] - nkq[1] ? "Yes" : "No");
            }
        }
    }
}
