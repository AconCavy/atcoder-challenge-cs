using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            const int N = 19;
            var (a, b) = (0, 0);
            var G = new char[19][];
            for (var i = 0; i < N; i++)
            {
                G[i] = Scanner.Scan<string>().ToCharArray();
                for (var j = 0; j < N; j++)
                {
                    if (G[i][j] == 'o') a++;
                    if (G[i][j] == 'x') b++;
                }
            }
            if (a == 0 && b == 0) { Console.WriteLine("YES"); return; }
            if (Math.Abs(a - b) > 1 || a < b) { Console.WriteLine("NO"); return; }

            var D8 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1), (1, 1), (1, -1), (-1, 1), (-1, -1) };
            bool Check()
            {
                for (var h = 0; h < N; h++)
                {
                    for (var w = 0; w < N; w++)
                    {
                        if (G[h][w] == '.') continue;
                        foreach (var (dh, dw) in D8)
                        {
                            var count = 0;
                            for (var m = 0; m <= 4; m++)
                            {
                                var (nh, nw) = (h + dh * m, w + dw * m);
                                if (nh < 0 || N <= nh || nw < 0 || N <= nw) break;
                                if (G[h][w] != G[nh][nw]) break;
                                count++;
                            }
                            if (count == 5) return true;
                        }
                    }
                }

                return false;
            }

            if (Check())
            {
                var c = a == b ? 'x' : 'o';
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (G[i][j] != c) continue;
                        G[i][j] = '.';
                        if (!Check())
                        {
                            Console.WriteLine("YES");
                            return;
                        }
                        G[i][j] = c;
                    }
                }
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
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
