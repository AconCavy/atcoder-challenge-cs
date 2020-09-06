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
            var nk = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var pn = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var max = 0.0;

            var cumSum = pn.CumulativeSum();

            for (var i = 0; i <= nk[0] - nk[1]; i++)
            {
                var sum = cumSum.ElementAt(i + nk[1]) - cumSum.ElementAt(i);
                if (max < sum) max = sum;
            }
            Console.WriteLine((max + nk[1]) / 2.0);
        }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<int> CumulativeSum(this IEnumerable<int> items)
        {
            if (items == null) throw new ArgumentNullException();
            var count = items.Count();
            if (count < 1) throw new ArgumentException();
            var array = new int[count + 1];
            array[0] = 0;
            for (var i = 1; i < array.Length; i++)
            {
                var index = i - 1;
                array[i] = items.ElementAt(index) + array[index];
            }
            return array;
        }
    }
}
