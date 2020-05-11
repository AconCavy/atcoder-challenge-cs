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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var xi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            if (nm[0] >= nm[1])
            {
                Console.WriteLine(0);
                return;
            }
            Array.Sort(xi);
            var distance = new int[xi.Length - 1];
            for (var i = 0; i < distance.Length; i++)
            {
                distance[i] = xi[i + 1] - xi[i];
            }
            Console.WriteLine(distance.OrderBy(x => x).Take(nm[1] - nm[0]).Sum());
        }
    }
}
