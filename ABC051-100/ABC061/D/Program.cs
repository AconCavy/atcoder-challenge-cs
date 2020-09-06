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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var edges = new (int U, int V, long S)[M];
            for (var i = 0; i < M; i++)
            {
                var abc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var (a, b) = (abc[0] - 1, abc[1] - 1);
                long c = -abc[2];
                edges[i] = (a, b, c);
            }

            const long Infinity = (long)1e18;
            var scores = Enumerable.Repeat(Infinity, N).ToArray();
            scores[0] = 0;
            for (var loop = 0; loop < N - 1; loop++)
            {
                for (var i = 0; i < M; i++)
                {
                    var u = edges[i].U;
                    var v = edges[i].V;
                    var s = edges[i].S;
                    if (scores[u] == Infinity) continue;
                    if (scores[v] > scores[u] + s) scores[v] = scores[u] + s;
                }
            }
            var answer = scores[N - 1];

            var negative = new bool[N];
            for (var loop = 0; loop < N; loop++)
            {
                for (var i = 0; i < M; i++)
                {
                    var u = edges[i].U;
                    var v = edges[i].V;
                    var s = edges[i].S;
                    if (scores[u] == Infinity) continue;

                    if (scores[v] > scores[u] + s)
                    {
                        scores[v] = scores[u] + s;
                        negative[v] = true;
                    }

                    if (negative[u]) negative[v] = true;
                }
            }

            Console.WriteLine(negative[N - 1] ? "inf" : (-answer).ToString());
        }
    }
}
