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
            var NH = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NH[0];
            var H = NH[1];
            var ab = new Tuple<int, int>[N];
            for (var i = 0; i < N; i++)
            {
                var tmp = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                ab[i] = new Tuple<int, int>(tmp[0], tmp[1]);
            }
            var answer = 0;
            var max = ab.Max(x => x.Item1);
            var sorted = ab.OrderByDescending(x => x.Item2).ToArray();
            for (var i = 0; i < sorted.Length; i++)
            {
                H -= sorted[i].Item2;
                answer++;
                if (H < 0)
                {
                    Console.WriteLine(answer);
                    return;
                }
            }

            answer += (int)Math.Ceiling((double)H / max);
            Console.WriteLine(answer);
        }
    }
}
