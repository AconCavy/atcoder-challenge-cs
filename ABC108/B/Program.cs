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
            var xyxy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var x1 = xyxy[0];
            var y1 = xyxy[1];
            var x2 = xyxy[2];
            var y2 = xyxy[3];
            var x = x2 - x1;
            var y = y2 - y1;
            Console.WriteLine($"{x2 - y} {y2 + x} {x1 - y} {y1 + x}");
        }
    }
}
