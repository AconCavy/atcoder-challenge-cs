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
            var n = int.Parse(Console.ReadLine());
            var points = new Point[n];
            var index = 0;
            for (var i = 0; i < points.Length; i++)
            {
                var xyh = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                points[i] = new Point { X = xyh[0], Y = xyh[1], H = xyh[2] };
                if (xyh[2] > 0) index = i;
            }

            for (var cx = 0; cx <= 100; cx++)
            {
                for (var cy = 0; cy <= 100; cy++)
                {
                    var h = Math.Abs(points[index].X - cx) + Math.Abs(points[index].Y - cy) + points[index].H;
                    var isValid = true;
                    for (var i = 0; i < points.Length; i++)
                    {
                        var tmpH = Math.Max(h - Math.Abs(points[i].X - cx) - Math.Abs(points[i].Y - cy), 0L);
                        if (points[i].H != tmpH)
                        {
                            isValid = false;
                            break;
                        }
                    }
                    if (isValid)
                    {
                        Console.WriteLine($"{cx} {cy} {h}");
                        return;
                    }
                }
            }
        }

        public struct Point
        {
            public long X { get; set; }
            public long Y { get; set; }
            public long H { get; set; }
        }
    }
}
