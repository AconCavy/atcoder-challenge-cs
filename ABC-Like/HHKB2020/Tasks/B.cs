using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
                var S = Scanner.Scan<string>();
                G[i] = S.Select(x => x == '.').ToArray();
            }
            var answer = 0;
            var dh = new[] { 0, 1 };
            var dw = new[] { 1, 0 };
            for (var i = 0; i < H; i++)
            {
                for (var j = 0; j < W; j++)
                {
                    if (!G[i][j]) continue;
                    for (var k = 0; k < 2; k++)
                    {
                        var nh = i + dh[k];
                        var nw = j + dw[k];
                        if (nh >= H || nw >= W) continue;
                        if (G[nh][nw]) answer++;
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
