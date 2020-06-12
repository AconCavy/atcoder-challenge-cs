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
            var N = int.Parse(Console.ReadLine());
            var ai = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var bi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var maxBit = 28;
            var answer = 0;
            // var bitsA = new int[N][];
            // var bitsB = new int[N][];
            // for (var i = 0; i < N; i++)
            // {
            //     bitsA[i] = GetBits(ai[i], maxBit);
            //     bitsB[i] = GetBits(ai[i], maxBit);
            // }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    answer ^= (ai[i] + bi[j]);
                }
            }
            Console.WriteLine(answer);
        }

        public static int[] GetBits(int n, int size = 32)
        {
            var bits = new int[size];
            for (var i = 0; i < size; i++) bits[i] = (n >> i) & 1;
            return bits;
        }
    }
}
