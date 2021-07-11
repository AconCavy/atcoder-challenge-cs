using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Tasks
{
    public class BD
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
            var (N, S) = Scanner.Scan<int, int>();
            var LB = new (int A, int B)[N];
            for (var i = 0; i < N; i++)
            {
                var (a, b) = Scanner.Scan<int, int>();
                LB[i] = (a, b);
            }

            var dp = new bool[N + 1, S + 1];
            var prev = new int[N + 1, S + 1];
            for (var i = 0; i <= N; i++)
            {
                for (var j = 0; j <= S; j++)
                {
                    prev[i, j] = -1;
                }
            }

            dp[0, 0] = true;

            for (var i = 0; i < N; i++)
            {
                var (a, b) = LB[i];
                for (var j = 0; j <= S; j++)
                {
                    if (j - a >= 0 && dp[i, j - a])
                    {
                        dp[i + 1, j] = true;
                        prev[i + 1, j] = j - a;
                    }

                    if (j - b >= 0 && dp[i, j - b])
                    {
                        dp[i + 1, j] = true;
                        prev[i + 1, j] = j - b;
                    }
                }
            }

            if (!dp[N, S])
            {
                Console.WriteLine("Impossible");
                return;
            }

            var curr = S;
            var rev = new StringBuilder();
            for (var i = N; i > 0; i--)
            {
                var p = prev[i, curr];
                if (curr - p == LB[i - 1].A) rev.Append('A');
                else if (curr - p == LB[i - 1].B) rev.Append('B');
                curr = p;
            }

            var answer = new string(rev.ToString().Reverse().ToArray());
            Console.WriteLine(answer);
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
