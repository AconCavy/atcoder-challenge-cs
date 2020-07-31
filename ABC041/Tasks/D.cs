using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
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

            // var graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            // for (var i = 0; i < M; i++)
            // {
            //     var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            //     var a = ab[0] - 1;
            //     var b = ab[1] - 1;
            //     graph[a].Add(b);
            // }

            var graph = new int[N];
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a] |= 1 << b;
            }

            var dp = new long[1 << N];
            dp[0] = 1;
            for (var s = 0; s < 1 << N; s++)
            {
                for (var i = 0; i < N; i++)
                {
                    if ((s >> i & 1) == 1)
                    {
                        // var ok = true;
                        // foreach (var e in graph[i])
                        // {
                        //     if ((bit >> e & 1) == 1) ok = false;
                        // }
                        // if (ok) dp[bit] += dp[bit ^ (1 << i)];

                        if ((s & graph[i]) == 0) dp[s] += dp[s ^ (1 << i)];
                    }
                }
            }

            Console.WriteLine(dp[(1 << N) - 1]);
        }
    }
}
