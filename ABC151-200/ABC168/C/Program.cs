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
            var abhm = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
            var h = (abhm[2] + (abhm[3] / 60.0)) * 30.0;
            var m = abhm[3] * 6.0;
            var angle = Math.Abs(h - m) * Math.PI / 180.0;
            var tmp = (abhm[0] * abhm[0]) + (abhm[1] * abhm[1]) - (2.0 * abhm[0] * abhm[1] * Math.Cos(angle));
            Console.WriteLine(Math.Sqrt(tmp));
        }
    }
}
