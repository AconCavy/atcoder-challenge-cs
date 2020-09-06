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
            var maxHonest = 0;
            var testimony = new Tuple<int, int>[n][];
            for (var i = 0; i < n; i++)
            {
                var a = int.Parse(Console.ReadLine());
                testimony[i] = new Tuple<int, int>[a];
                for (var j = 0; j < a; j++)
                {
                    var xy = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                    testimony[i][j] = new Tuple<int, int>(xy[0] - 1, xy[1]);
                }
            }

            foreach (var bit in BitFullSearchEnumerable(n))
            {
                var honest = bit.Count(x => x);
                var valid = true;
                for (var i = 0; i < n; i++)
                {
                    if (bit[i])
                    {
                        for (var j = 0; j < testimony[i].Length; j++)
                        {
                            var target = testimony[i][j].Item1;
                            var isHonest = testimony[i][j].Item2 == 1;
                            if (bit[target] != isHonest)
                            {
                                valid = false;
                                break;
                            }
                        }
                    }
                }
                if (valid) maxHonest = Math.Max(maxHonest, honest);
            }
            Console.WriteLine(maxHonest);
        }

        static IEnumerable<bool[]> BitFullSearchEnumerable(int n)
        {
            if (n < 0) yield return new bool[0];
            for (var i = 0; i < Math.Pow(2, n); i++)
            {
                var array = new bool[n];
                for (var j = 0; j < n; j++)
                {
                    var right = (i >> j) & 1;
                    array[j] = right == 1;
                }
                yield return array;
            }
        }
    }
}
