using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (N, C) = Scanner.Scan<int, int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var ids = new List<int>[C + 1].Select(_ => new List<int> { 0 }).ToArray();
            for (var i = 0; i < N; i++)
            {
                if (1 <= A[i] && A[i] <= C)
                {
                    ids[A[i]].Add(i + 1);
                }
            }

            for (var i = 0; i <= C; i++)
            {
                ids[i].Add(N + 1);
            }

            var all = (long)N * (N + 1) / 2;

            for (var i = 1; i <= C; i++)
            {
                var answer = all;
                for (var j = 1; j < ids[i].Count; j++)
                {
                    var d = (long)ids[i][j] - ids[i][j - 1] - 1;
                    answer -= d * (d + 1) / 2;
                }

                Console.WriteLine(answer);
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
