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
            var s = Console.ReadLine();
            var counts = new int[s.Length];
            var rl = new List<int>();
            Func<int, int, int> Dist = (from, to) => Math.Abs(from - to);
            for (var i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == 'R' && s[i + 1] == 'L') rl.Add(i);
            }
            rl.Add(rl.Count * 2);

            for (var i = 0; i < s.Length; i++)
            {
                var r = rl[0];
                var dist = Dist(i, r);
                if (i <= r + 1)
                {
                    if (dist % 2 == 0) counts[r]++;
                    else counts[r + 1]++;
                    continue;
                }
                var nr = rl[1];
                var distNext = Dist(i, nr);
                if (s[i] == 'R')
                {
                    if (distNext % 2 == 0) counts[nr]++;
                    else counts[nr + 1]++;
                    rl.RemoveAt(0);
                }
                else
                {
                    if (dist % 2 == 0) counts[r]++;
                    else counts[r + 1]++;
                }
            }

            Console.WriteLine(string.Join(" ", counts));
        }
    }
}
