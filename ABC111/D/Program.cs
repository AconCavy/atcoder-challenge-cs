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
            var points = new Point<long, long>[n];
            for (var i = 0; i < n; i++)
            {
                var xy = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                points[i] = new Point { X = xy[0], Y = xy[1] };
            }
        }

        public struct Point
        {
            public long X { get; set; }
            public long Y { get; set; }
        }
    }
}
