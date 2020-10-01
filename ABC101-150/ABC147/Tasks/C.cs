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
            var N = Scanner.Scan<int>();
            var Q = new (int X, bool Y)[N][];
            for (var i = 0; i < N; i++)
            {
                var A = Scanner.Scan<int>();
                Q[i] = new (int X, bool Y)[A];
                for (var j = 0; j < A; j++)
                {
                    var (x, y) = Scanner.Scan<int, int>();
                    Q[i][j] = (x - 1, y == 1);
                }
            }

            var answer = 0;
            for (var s = 0; s < 1 << N; s++)
            {
                var honest = new bool[N];
                var count = 0;
                for (var i = 0; i < N; i++)
                {
                    if ((s >> i & 1) == 1)
                    {
                        honest[i] = true;
                        count++;
                    }
                }

                var ok = true;
                for (var i = 0; i < N & ok; i++)
                {
                    if (!honest[i]) continue;
                    for (var j = 0; j < Q[i].Length & ok; j++)
                    {
                        var x = Q[i][j].X;
                        var y = Q[i][j].Y;
                        if (honest[x] != y) ok = false;
                    }
                }

                if (ok) answer = Math.Max(answer, count);
            }
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
