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
            var (N, A, B, C) = Scanner.Scan<int, int, int, int>();
            var L = new int[N].Select(_ => Scanner.Scan<int>()).ToArray();
            const int inf = (int)1e9;

            int Dfs(int step, int a, int b, int c)
            {
                var min = new[] { a, b, c }.Min();
                if (step == N) return min > 0 ? Math.Abs(A - a) + Math.Abs(B - b) + Math.Abs(C - c) - 30 : inf;

                min = new[]{
                    Dfs(step + 1, a, b, c),
                    Dfs(step + 1, a + L[step], b, c) + 10,
                    Dfs(step + 1, a, b + L[step], c) + 10,
                    Dfs(step + 1, a, b, c + L[step]) + 10
                }.Min();
                return min;
            }

            Console.WriteLine(Dfs(0, 0, 0, 0));
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
