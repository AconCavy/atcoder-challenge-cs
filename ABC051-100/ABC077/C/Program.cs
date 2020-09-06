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
            var B = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var C = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(A);
            Array.Sort(B);
            Array.Sort(C);
            var answer = 0L;

            for (var i = 0; i < N; i++)
            {
                long ab = LowerBound(A, B[i]);
                long bc = N - UpperBound(C, B[i]);
                answer += ab * bc;
            }
            Console.WriteLine(answer);
        }

        public static int LowerBound<T>(IEnumerable<T> items, T key, Comparer<T> comparer = null)
        {
            return LowerBound(items.ToArray(), key, comparer);
        }

        public static int LowerBound<T>(T[] items, T key, Comparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            var left = 0;
            var right = items.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (comparer.Compare(items[mid], key) == -1) left = mid + 1;
                else right = mid - 1;
            }

            return left;
        }

        public static int UpperBound<T>(IEnumerable<T> items, T key, Comparer<T> comparer = null)
        {
            return UpperBound(items.ToArray(), key, comparer);
        }

        public static int UpperBound<T>(T[] items, T key, Comparer<T> comparer = null)
        {
            comparer ??= Comparer<T>.Default;
            var left = 0;
            var right = items.Length - 1;
            while (left <= right)
            {
                var mid = left + (right - left) / 2;
                if (comparer.Compare(items[mid], key) <= 0) left = mid + 1;
                else right = mid - 1;
            }

            return left;
        }
    }
}
