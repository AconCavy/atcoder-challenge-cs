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
            var n = int.Parse(Console.ReadLine());
            var di = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sum = 0;
            for (var i = 0; i < di.Length - 1; i++)
            {
                for (var j = i + 1; j < di.Length; j++)
                {
                    sum += di[i] * di[j];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
