using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var (N, M) = Scanner.Scan<int, int>();
            var inf = (int)1e9;
            var G = new int[N][].Select(x => x = Enumerable.Repeat(inf, N).ToArray()).ToArray();
            var toOne = new List<(int V, int L)>();
            for (var i = 0; i < M; i++)
            {
                var (u, v, l) = Scanner.Scan<int, int, int>();
                u--;
                v--;
                if (u == 0) toOne.Add((v, l));
                else if (v == 0) toOne.Add((u, l));
                else G[u][v] = G[v][u] = l;
            }

            for (var k = 0; k < N; k++)
            {
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        G[i][j] = Math.Min(G[i][j], G[i][k] + G[k][j]);
                    }
                }
            }

            var answer = inf;
            for (var i = 0; i < toOne.Count; i++)
            {
                for (var j = 0; j < toOne.Count; j++)
                {
                    if (i == j) continue;
                    var u = toOne[i].V;
                    var v = toOne[j].V;
                    var l = toOne[i].L + toOne[j].L;
                    answer = Math.Min(answer, G[u][v] + l);
                }
            }

            if (answer == inf) answer = -1;
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
