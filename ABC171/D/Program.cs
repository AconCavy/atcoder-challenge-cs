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
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var Q = int.Parse(Console.ReadLine());
            var dict = new Dictionary<long, long>();
            var answer = 0L;
            for (var i = 0; i < A.Length; i++)
            {
                if (dict.ContainsKey(A[i])) dict[A[i]]++;
                else dict[A[i]] = 1L;
                answer += A[i];
            }

            for (var i = 0; i < Q; i++)
            {
                var BC = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                var B = BC[0];
                var C = BC[1];
                if (!dict.ContainsKey(B)) dict[B] = 0L;
                if (!dict.ContainsKey(C)) dict[C] = 0L;
                dict[C] += dict[B];
                answer += (C - B) * dict[B];
                dict[B] = 0L;
                Console.WriteLine(answer);
            }
        }
    }
}
