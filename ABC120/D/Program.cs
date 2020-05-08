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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var briges = new Brige[nm[1]];
            var max = (nm[0] * nm[1]) / 2;
            for (var i = 0; i < nm[1]; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                briges[i] = new Brige { A = ab[0] - 1, B = ab[1] - 1 };
            }
            
            for (var i = 0; i < briges.Length; i++)
            {
                Console.WriteLine(max - i);
            }

        }

        public struct Brige
        {
            public int A;
            public int B;
        }
    }
}
