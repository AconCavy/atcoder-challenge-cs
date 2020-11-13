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
            var (N, C) = Scanner.Scan<int, int>();
            var D = new int[C][].Select(_ => Scanner.ScanEnumerable<int>().ToArray()).ToArray();
            var colors = new int[3, C];
            for (var i = 0; i < N; i++)
            {
                var color = Scanner.ScanEnumerable<int>().ToArray();
                for (var j = 0; j < N; j++)
                {
                    colors[(i + j) % 3, color[j] - 1]++;
                }
            }

            const long linf = (long)1e18;
            var answer = linf;
            for (var i = 0; i < C; i++)
            {
                for (var j = 0; j < C; j++)
                {
                    if (i == j) continue;
                    for (var k = 0; k < C; k++)
                    {
                        if (k == i || k == j) continue;
                        var tmp = 0L;
                        for (var t = 0; t < C; t++)
                        {
                            tmp += colors[0, t] * D[t][i];
                            tmp += colors[1, t] * D[t][j];
                            tmp += colors[2, t] * D[t][k];
                        }

                        answer = Math.Min(answer, tmp);
                    }
                }
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
