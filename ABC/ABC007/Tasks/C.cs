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
            var (R, C) = Scanner.Scan<int, int>();
            var (Sy, Sx) = Scanner.Scan<int, int>();
            Sy--;
            Sx--;
            var (Gy, Gx) = Scanner.Scan<int, int>();
            Gy--;
            Gx--;
            var G = new string[R];
            for (var i = 0; i < R; i++)
            {
                G[i] = Scanner.Scan<string>();
            }

            var queue = new Queue<(int y, int x)>();
            queue.Enqueue((Sy, Sx));
            var depths = new int[R][].Select(x => Enumerable.Repeat(-1, C).ToArray()).ToArray();
            depths[Sy][Sx] = 0;
            var dy = new[] { 0, 1, 0, -1 };
            var dx = new[] { -1, 0, 1, 0 };
            while (queue.Any())
            {
                var (cy, cx) = queue.Dequeue();
                for (var i = 0; i < 4; i++)
                {
                    var ny = cy + dy[i];
                    var nx = cx + dx[i];
                    if (ny < 0 || R <= ny) continue;
                    if (nx < 0 || C <= nx) continue;
                    if (G[ny][nx] == '#') continue;
                    if (depths[ny][nx] != -1) continue;
                    depths[ny][nx] = depths[cy][cx] + 1;
                    queue.Enqueue((ny, nx));
                }
            }

            // Console.WriteLine(string.Join("\n", depths.Select(x => string.Join("", x))));

            Console.WriteLine(depths[Gy][Gx]);
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
