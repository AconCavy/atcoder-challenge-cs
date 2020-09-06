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
            var n = int.Parse(Console.ReadLine());
            var li = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(li);
            var count = 0;
            for (var i = 0; i < li.Length - 2; i++)
            {
                for (var j = i + 1; j < li.Length - 1; j++)
                {
                    var threthold = li[i] + li[j];
                    var min = -1;
                    var max = li.Length;
                    while (max - min > 1)
                    {
                        var mid = (min + max) / 2;
                        if (li[mid] >= threthold) max = mid;
                        else min = mid;
                    }
                    if (min > j) count += min - j;
                }
            }
            Console.WriteLine(count);
        }
    }
}
