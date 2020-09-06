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
            var vi = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var even = new Dictionary<int, int>();
            var odd = new Dictionary<int, int>();
            for (var i = 0; i < vi.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (even.ContainsKey(vi[i])) even[vi[i]]++;
                    else even.Add(vi[i], 1);
                }
                else
                {
                    if (odd.ContainsKey(vi[i])) odd[vi[i]]++;
                    else odd.Add(vi[i], 1);
                }
            }
            var evenOrder = even.Select(dict => new { X = dict.Key, Count = dict.Value }).OrderByDescending(x => x.Count).ToArray();
            var oddOrder = odd.Select(dict => new { X = dict.Key, Count = dict.Value }).OrderByDescending(x => x.Count).ToArray();

            var evenMax = evenOrder[0].Count;
            var oddMax = oddOrder[0].Count;
            if (evenOrder[0].X == oddOrder[0].X)
            {
                var tmpEven = evenOrder.Length > 1 ? evenOrder[1].Count : 0;
                var tmpOdd = oddOrder.Length > 1 ? oddOrder[1].Count : 0;
                if (tmpEven > tmpOdd) evenMax = tmpEven;
                else oddMax = tmpOdd;
            }

            var answer = vi.Length - evenMax - oddMax;
            Console.WriteLine(answer);
        }
    }
}
