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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var ai = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            Array.Sort(ai);
            var query = new Tuple<long, long>[nm[1]];
            for (var i = 0; i < nm[1]; i++)
            {
                var bc = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
                query[i] = new Tuple<long, long>(bc[0], bc[1]);
            }
            query = query.OrderByDescending(x => x.Item2).ThenByDescending(x => x.Item1).ToArray();
            var aiIndex = 0;
            var queryIndex = 0;
            while (aiIndex < ai.Length && queryIndex < query.Length)
            {
                if (ai[aiIndex] < query[queryIndex].Item2)
                {
                    for (var i = 0; i < query[queryIndex].Item1; i++)
                    {
                        if (ai[aiIndex] >= query[queryIndex].Item2) break;
                        ai[aiIndex] = query[queryIndex].Item2;
                        if (++aiIndex >= ai.Length) break;
                    }
                }
                queryIndex++;
            }
            Console.WriteLine(ai.Sum());
        }
    }
}
