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
            var A = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var answer = new List<Tuple<int, int>>();

            var max = (int)-1e6 - 1;
            var min = (int)1e6 + 1;
            var maxIndex = 0;
            var minIndex = 0;
            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                    maxIndex = i;
                }
                if (A[i] < min)
                {
                    min = A[i];
                    minIndex = i;
                }
            }

            if (Math.Abs(max) >= Math.Abs(min))
            {
                for (var i = 0; i < A.Length; i++)
                {
                    answer.Add(new Tuple<int, int>(maxIndex + 1, i + 1));
                }
                for (var i = 1; i < A.Length; i++)
                {
                    answer.Add(new Tuple<int, int>(i, i + 1));
                }
            }
            else
            {
                for (var i = 0; i < A.Length; i++)
                {
                    answer.Add(new Tuple<int, int>(minIndex + 1, i + 1));
                }
                for (var i = A.Length - 1; i > 0; i--)
                {
                    answer.Add(new Tuple<int, int>(i, i + 1));
                }
            }

            Console.WriteLine(answer.Count);
            foreach (var item in answer)
            {
                Console.WriteLine($"{item.Item1} {item.Item2}");
            }
        }
    }
}
