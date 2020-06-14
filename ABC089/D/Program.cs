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
            var HWD = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var H = HWD[0];
            var W = HWD[1];
            var D = HWD[2];
            var A = new Location[H * W];
            for (var i = 0; i < H; i++)
            {
                var a = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                for (var j = 0; j < a.Length; j++)
                {
                    A[a[j] - 1] = new Location { X = j, Y = i };
                }
            }

            var costs = new int[H * W];
            for (var i = 0; i < D; i++)
            {
                var prev = A[i];
                for (var j = D; i + j < H * W; j += D)
                {
                    var current = A[i + j];
                    costs[i + j] = Math.Abs(current.X - prev.X) + Math.Abs(current.Y - prev.Y) + costs[i + j - D];
                    prev = current;
                }
            }

            var Q = int.Parse(Console.ReadLine());
            for (var i = 0; i < Q; i++)
            {
                var LR = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var L = LR[0] - 1;
                var R = LR[1] - 1;
                Console.WriteLine(costs[R] - costs[L]);
            }
        }

        public class Location
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
