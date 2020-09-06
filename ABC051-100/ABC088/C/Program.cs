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
            var c = new int[3][].Select(x => Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray()).ToArray();

            var a11b22c33 = c[0][0] + c[1][1] + c[2][2];
            var a12b23c31 = c[0][1] + c[1][2] + c[2][0];
            var a13b21c32 = c[0][2] + c[1][0] + c[2][1];

            Console.WriteLine(a11b22c33 == a12b23c31 && a12b23c31 == a13b21c32 ? "Yes" : "No");

        }
    }
}
