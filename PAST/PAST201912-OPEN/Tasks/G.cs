using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class G
    {
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var G = new long[N, N];
            for (var i = 0; i < N - 1; i++)
            {
                var A = Scanner.ScanEnumerable<int>().ToArray();
                for (var j = 0; j < A.Length; j++)
                {
                    G[i, i + j + 1] = G[i + j + 1, i] = A[j];
                }
            }

            const long inf = (long)1e18;
            var answer = -inf;

            var group = new List<int>[3].Select(_ => new List<int>()).ToArray();
            void Dfs(int idx)
            {
                if (idx == N)
                {
                    var sum = 0L;
                    for (var g = 0; g < 3; g++)
                    {
                        for (var i = 0; i < group[g].Count; i++)
                        {
                            for (var j = i + 1; j < group[g].Count; j++)
                            {
                                sum += G[group[g][i], group[g][j]];
                            }
                        }
                    }

                    answer = Math.Max(answer, sum);
                    return;
                }

                for (var g = 0; g < 3; g++)
                {
                    group[g].Add(idx);
                    Dfs(idx + 1);
                    group[g].Remove(idx);
                }
            }

            Dfs(0);

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
