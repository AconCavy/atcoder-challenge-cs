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
            var pi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var qi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Func<IEnumerable<int>, long> func = items =>
            {
                var count = items.Count();
                var copiedItems = items.ToList();
                copiedItems.Sort();
                var index = 0L;
                for (var i = 0; i < count - 1; i++)
                {
                    var k = count - i - 1;
                    var val = items.ElementAt(i);
                    var region = PermutationCount(k, k) * (copiedItems.IndexOf(val));
                    copiedItems.Remove(val);
                    index += region;
                }
                return index;
            };
            Console.WriteLine(Math.Abs(func(pi) - func(qi)));
        }

        static long PermutationCount(int n, int k)
        {
            if (n < k) throw new ArgumentException();
            long result = n;
            for (var i = 1; i < k; i++)
                result *= (n - i);
            return result;
        }
    }
}
