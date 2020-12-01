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
            var (N, M, D) = Scanner.Scan<int, int, int>();
            var A = M > 0 ? Scanner.ScanEnumerable<int>().ToArray() : Array.Empty<int>();
            const int upper = 32;
            var T = new int[upper][].Select(_ => new int[N]).ToArray();
            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                T[0][i] = i;
                answer[i] = i;
            }

            for (var i = M - 1; i >= 0; i--)
            {
                (T[0][A[i]], T[0][A[i] - 1]) = (T[0][A[i] - 1], T[0][A[i]]);
            }

            for (var i = 1; i < upper; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    T[i][j] = T[i - 1][T[i - 1][j]];
                }
            }

            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < upper; j++)
                {
                    if ((D >> j & 1) == 0) continue;
                    answer[i] = T[j][answer[i]];
                }
            }

            Console.WriteLine(string.Join("\n", answer.Select(x => x + 1)));
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
