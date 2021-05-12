using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var S = Scanner.Scan<string>();
            var (Gx, Gy) = Scanner.Scan<int, int>();

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            bool Check(int w, int x, int y, int z)
            {
                var (cx, cy) = (0, 0);
                foreach (var c in S)
                {
                    if ((cx, cy) == (Gx, Gy)) return true;
                    var (dx, dy) = c switch
                    {
                        'W' => D4[w],
                        'X' => D4[x],
                        'Y' => D4[y],
                        'Z' => D4[z],
                        _ => (0, 0)
                    };

                    cx += dx;
                    cy += dy;
                }

                return (cx, cy) == (Gx, Gy);
            }

            for (var w = 0; w < 4; w++)
            {
                for (var x = 0; x < 4; x++)
                {
                    if (x == w) continue;
                    for (var y = 0; y < 4; y++)
                    {
                        if (y == w || y == x) continue;
                        for (var z = 0; z < 4; z++)
                        {
                            if (z == w || z == x || z == y) continue;
                            if (Check(w, x, y, z))
                            {
                                Console.WriteLine("Yes");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("No");
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
