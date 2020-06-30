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

        static int R;
        static int[] r;
        static bool[] checker = new bool[8];
        static int[][] path;
        static int limit = (int)1e9;
        static int answer;

        public static void Solve()
        {
            var NMR = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NMR[0];
            var M = NMR[1];
            R = NMR[2];
            r = Console.ReadLine().Trim().Split(' ').Select(x => int.Parse(x) - 1).ToArray();
            path = (new int[N][]).Select(x => x = Enumerable.Repeat(limit, N).ToArray()).ToArray();
            for (var i = 0; i < N; i++)
            {
                path[i][i] = 0;
            }
            for (var i = 0; i < M; i++)
            {
                var ABC = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var A = ABC[0] - 1;
                var B = ABC[1] - 1;
                var C = ABC[2];
                path[A][B] = path[B][A] = Math.Min(path[A][B], C);
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        path[i][j] = Math.Min(path[i][j], path[i][k] + path[k][j]);
                    }
                }
            }

            answer = limit;
            Dfs();
            Console.WriteLine(answer);
        }

        public static void Dfs(int step = 0, int current = -1, int sum = 0)
        {
            if (step == R)
            {
                answer = Math.Min(answer, sum);
                return;
            }
            for (var next = 0; next < R; next++)
            {
                if (checker[next]) continue;
                checker[next] = true;
                if (current == -1) Dfs(step + 1, next);
                else Dfs(step + 1, next, sum + path[r[current]][r[next]]);
                checker[next] = false;
            }
        }
    }
}
