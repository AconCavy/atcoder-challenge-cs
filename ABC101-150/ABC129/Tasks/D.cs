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
            var (H, W) = Scanner.Scan<int, int>();
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = Scanner.Scan<string>().Select(x => x == '.').ToArray();
            }

            var h = new int[H][].Select(_ => new int[W]).ToArray();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (!G[i][j]) continue;
                    if (i > 0 && G[i - 1][j]) { h[i][j] = h[i - 1][j]; continue; }
                    for (var k = i; k < H; k++)
                    {
                        if (G[k][j]) h[i][j]++;
                        else break;
                    }
                }
            }
            var w = new int[H][].Select(_ => new int[W]).ToArray();
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (!G[i][j]) continue;
                    if (j > 0 && G[i][j - 1]) { w[i][j] = w[i][j - 1]; continue; }
                    for (var k = j; k < W; k++)
                    {
                        if (G[i][k]) w[i][j]++;
                        else break;
                    }
                }
            }

            var answer = 0;
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    answer = Math.Max(answer, h[i][j] + w[i][j] - 1);
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
