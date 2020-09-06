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
            var Q = int.Parse(Console.ReadLine());
            for (var i = 0; i < Q; i++)
            {
                var AB = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var (A, B) = (AB[0], AB[1]);
                Console.WriteLine(answer);
            }
        }
    }
}
