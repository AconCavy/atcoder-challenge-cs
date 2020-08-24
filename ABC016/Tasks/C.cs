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
            var G = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var (A, B) = Scanner.Scan<int, int>();
                A--;
                B--;
                G[A].Add(B);
                G[B].Add(A);
            }

            var friends = new int[N][].Select(x => new int[N]).ToArray();

            for (var i = 0; i < N; i++)
            {
                var queue = new Queue<int>();
                queue.Enqueue(i);
                var depths = Enumerable.Repeat(-1, N).ToArray();
                depths[i] = 0;
                while (queue.Any())
                {
                    var current = queue.Dequeue();
                    foreach (var next in G[current])
                    {
                        if (depths[next] != -1) continue;
                        depths[next] = depths[current] + 1;
                        if (depths[current] < 1)
                        {
                            friends[i][next] = -1;
                            friends[next][i] = -1;
                            queue.Enqueue(next);
                        }
                        else
                        {
                            if (friends[i][next] != 1)
                            {
                                friends[i][next] = 1;
                                friends[next][i] = 1;
                            }
                        }
                    }
                }
                Console.WriteLine(friends[i].Count(x => x > 0));
            }
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
        }
    }
}
