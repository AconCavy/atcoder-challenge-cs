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
            var N = int.Parse(Console.ReadLine());
            var abi = new Pair[N];
            var cdi = new Pair[N];
            for (var i = 0; i < N; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                abi[i] = new Pair { X = ab[0], Y = ab[1] };
            }
            for (var i = 0; i < N; i++)
            {
                var cd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                cdi[i] = new Pair { X = cd[0], Y = cd[1] };
            }
            abi = abi.OrderByDescending(x => x.Y).ToArray();
            cdi = cdi.OrderBy(x => x.X).ToArray();

            var answer = 0;
            var hash = new HashSet<int>();
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    if (!hash.Contains(j) && abi[i].X < cdi[j].X && abi[i].Y < cdi[j].Y)
                    {
                        answer++;
                        hash.Add(j);
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
        }

        public class Pair
        {
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
