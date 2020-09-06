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
            var answer = H * W;
            var G = new bool[H][];
            for (var i = 0; i < H; i++)
            {
                G[i] = new bool[W];
                var S = Scanner.Scan<string>();
                for (var j = 0; j < S.Length; j++)
                {
                    G[i][j] = S[j] == '.';
                    if (!G[i][j]) answer--;
                }
            }

            var queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));
            var depths = new int[H][].Select(x => Enumerable.Repeat(-1, W).ToArray()).ToArray();
            depths[0][0] = 0;
            while (queue.Any())
            {
                var current = queue.Dequeue();
                var x = current.Item1;
                var y = current.Item2;
                var nextDir = new List<(int, int)>();
                if (x > 0 && G[y][x - 1]) nextDir.Add((x - 1, y));
                if (x < W - 1 && G[y][x + 1]) nextDir.Add((x + 1, y));
                if (y > 0 && G[y - 1][x]) nextDir.Add((x, y - 1));
                if (y < H - 1 && G[y + 1][x]) nextDir.Add((x, y + 1));

                foreach (var next in nextDir)
                {
                    var nx = next.Item1;
                    var ny = next.Item2;

                    if (depths[ny][nx] != -1) continue;
                    depths[ny][nx] = depths[y][x] + 1;
                    queue.Enqueue(next);
                }
            }
            if (depths[H - 1][W - 1] == -1)
            {
                Console.WriteLine(-1);
                return;
            }
            answer -= depths[H - 1][W - 1] + 1;
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
