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
            var nd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var count = 0;
            var points = new int[nd[0]][];
            for (var i = 0; i < nd[0]; i++)
            {
                points[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            for (var i = 0; i < points.Length - 1; i++)
            {
                for (var j = i + 1; j < points.Length; j++)
                {
                    var dist = Distance(points[i], points[j]);
                    var tmp = (long)Math.Sqrt(dist);
                    for (var k = tmp - 1; k <= tmp + 1; k++)
                    {
                        if (k * k == dist) count++;
                    }
                }
            }
            Console.WriteLine(count);
        }

        static double Distance(IEnumerable<int> a, IEnumerable<int> b)
        {
            if (a.Count() != b.Count()) throw new ArgumentException();
            var sum = 0;
            for (var i = 0; i < a.Count(); i++)
            {
                var tmp = a.ElementAt(i) - b.ElementAt(i);
                sum += (tmp * tmp);
            }
            return sum;
        }
    }
}
