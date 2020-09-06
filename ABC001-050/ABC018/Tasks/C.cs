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
            var (R, C, K) = Scanner.Scan<int, int, int>();
            var G = new string[R];
            for (var i = 0; i < R; i++)
            {
                G[i] = Scanner.Scan<string>();
            }

            var counts = new (int T, int B)[R][].Select(x => x = new (int T, int B)[C]).ToArray();
            for (var i = 0; i < R; i++)
            {
                for (var j = 0; j < C; j++)
                {
                    var t = 0;
                    var b = 0;
                    for (var k = 0; i - k >= 0; k++)
                    {
                        if (G[i - k][j] == 'o') t++;
                        else break;
                    }
                    for (var k = 0; i + k < R; k++)
                    {
                        if (G[i + k][j] == 'o') b++;
                        else break;
                    }
                    counts[i][j] = (t, b);
                }
            }

            // Console.WriteLine(string.Join("\n", counts.Select(x => string.Join(" ", x.Select(y => $"({y.T} {y.B})")))));

            var answer = 0;
            for (var i = K - 1; i < R - K + 1; i++)
            {
                for (var j = K - 1; j < C - K + 1; j++)
                {
                    var ok = true;
                    for (var k = 0; k < K && ok; k++)
                    {
                        var p = counts[i][j + k];
                        var c = K - k;
                        if (p.T < c || p.B < c) ok = false;
                        p = counts[i][j - k];
                        if (p.T < c || p.B < c) ok = false;
                    }
                    if (ok) answer++;
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
        }
    }
}
