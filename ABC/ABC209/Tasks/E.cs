using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace Tasks
{
    public class E
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
            var E = new (string S, string T)[N];
            var dict = new Dictionary<string, int>();
            var M = 0;
            for (var i = 0; i < N; i++)
            {
                var s = Scanner.Scan<string>();
                var a = s[..3];
                var b = s[^3..];
                E[i] = (a, b);
                if (!dict.ContainsKey(a)) dict[a] = M++;
                if (!dict.ContainsKey(b)) dict[b] = M++;
            }

            var G = new List<int>[M].Select(x => new List<int>()).ToArray();
            var indeg = new int[M];
            foreach (var (s, t) in E)
            {
                var u = dict[s];
                var v = dict[t];
                G[v].Add(u);
                indeg[u]++;
            }

            var memo = new int[M];
            Array.Fill(memo, -1);
            var queue = new Queue<int>();

            for (var i = 0; i < M; i++)
            {
                if (indeg[i] != 0) continue;
                memo[i] = 0;
                queue.Enqueue(i);
            }

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();
                foreach (var v in G[u])
                {
                    if (memo[v] != -1) continue;
                    indeg[v]--;
                    if (memo[u] == 0)
                    {
                        memo[v] = 1;
                        queue.Enqueue(v);
                    }
                    else if (indeg[v] == 0)
                    {
                        memo[v] = 0;
                        queue.Enqueue(v);
                    }
                }
            }

            foreach (var (_, t) in E)
            {
                var answer = memo[dict[t]] switch
                {
                    -1 => "Draw",
                    0 => "Takahashi",
                    1 => "Aoki",
                    _ => throw new InvalidOperationException()
                };

                Console.WriteLine(answer);
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
