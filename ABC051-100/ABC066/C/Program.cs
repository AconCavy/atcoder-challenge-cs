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
            var N = int.Parse(Console.ReadLine());
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = new int[N];
            answer[N / 2] = A[0];
            for (var i = 1; i < A.Length; i++)
            {
                var dx = (i + 1) / 2;
                if (i % 2 == 1) dx = -dx;
                answer[N / 2 + dx] = A[i];
            }
            if (N % 2 == 1) answer = answer.Reverse().ToArray();

            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
