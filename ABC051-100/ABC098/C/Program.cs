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
            var s = Console.ReadLine();
            var tmp = new int[n];
            for (var i = 0; i < tmp.Length; i++)
            {
                if (s[i] == 'W') tmp[i] = 0;
                else tmp[i] = 1;
            }
            var agg = CumulativeSum(tmp).ToArray();
            var answer = n;
            for (var i = 0; i < agg.Length; i++)
            {
                var left = i - agg[i];
                var right = agg[agg.Length - 1] - agg[i];
                answer = Math.Min(answer, left + right);
            }
            Console.WriteLine(answer);
        }

        public static IEnumerable<int> CumulativeSum(IEnumerable<int> items)
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
