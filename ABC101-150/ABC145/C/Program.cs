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
            var n = int.Parse(Console.ReadLine());
            var points = new Tuple<double, double>[n];
            for (var i = 0; i < n; i++)
            {
                var xy = Console.ReadLine().Trim().Split(' ').Select(double.Parse).ToArray();
                points[i] = new Tuple<double, double>(xy[0], xy[1]);
            }
            var sum = 0.0;
            var all = (double)PermutationCount(n, n);
            foreach (var point in Permutation(points, points.Length))
            {
                for (var i = 0; i < point.Count() - 1; i++)
                {
                    var dx = point.ElementAt(i).Item1 - point.ElementAt(i + 1).Item1;
                    var dy = point.ElementAt(i).Item2 - point.ElementAt(i + 1).Item2;
                    sum += Math.Sqrt(dx * dx + dy * dy);
                }
            }
            Console.WriteLine(sum / all);
        }

        static long PermutationCount(int n, int k)
        {
            if (n < k) throw new ArgumentException();
            long result = n;
            for (var i = 1; i < k; i++)
                result *= (n - i);
            return result;
        }

        static IEnumerable<IEnumerable<T>> Permutation<T>(IEnumerable<T> items, int k)
        {
            if (k == 1)
            {
                foreach (var next in items)
                    yield return new T[] { next };
                yield break;
            }
            foreach (var item in items)
            {
                var fixedItems = new T[] { item };
                var exceptedItems = items.Except(fixedItems);
                foreach (var next in Permutation(exceptedItems, k - 1))
                    yield return fixedItems.Concat(next).ToArray();
            }
        }
    }
}
