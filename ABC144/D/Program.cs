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
            var abx = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Func<double, double, double, double> calcDifferenceVolume = (a, b, theta) =>
            {
                if (a * Math.Tan(theta) <= b)
                    return a * a * b - a * a * a * Math.Tan(theta) / 2.0;
                return b * b / Math.Tan(theta) * a / 2.0;
            };
            var valid = Math.PI / 2.0;
            var invalid = 0.0;
            for (var i = 1; i < 100000; i++)
            {
                var mid = (valid + invalid) / 2.0;
                if (calcDifferenceVolume(abx[0], abx[1], mid) < abx[2]) valid = mid;
                else invalid = mid;
            }
            Console.WriteLine(valid / Math.PI * 180);
        }
    }
}
