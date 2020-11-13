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
            var (N, M, Q) = Scanner.Scan<int, int, int>();
            var Query = new (int A, int B, int C, int D)[Q];
            for (var i = 0; i < Q; i++)
            {
                var (a, b, c, d) = Scanner.Scan<int, int, int, int>();
                Query[i] = (a - 1, b - 1, c, d);
            }

            var answer = 0;

            void Dfs(IEnumerable<int> items)
            {
                var list = items.ToList();
                if (list.Count == N)
                {
                    var score = Query.Where(x => list[x.B] - list[x.A] == x.C).Sum(x => x.D);
                    answer = Math.Max(answer, score);
                    return;
                }

                list.Add(list[^1]);
                while (list[^1] <= M) { Dfs(list); list[^1]++; }
            }

            Dfs(new[] { 1 });
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
