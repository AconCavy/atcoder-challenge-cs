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

            var answer = true;
            var D4 = new[] { (1, 0), (0, 1), (1, 1), (1, -1) };

            int GetCount(int h, int w, int k)
            {
                var ret = 1;
                var (dh, dw) = D4[k];
                foreach (var d in new[] { 1, -1 })
                {
                    for (var m = 1; m <= 10; m++)
                    {
                        var (nh, nw) = (h + dh * d * m, w + dw * d * m);
                        if (nh < 0 || N <= nh || nw < 0 || N <= nw) continue;
                        if (G[h][w] == G[nh][nw]) continue;
                        ret += m - 1;
                        break;
                    }
                }

                return ret;
            }

            var ca = new bool[N, N, 4];
            var cb = new bool[N, N, 4];
            var (a5, b5) = (0, 0);
            for (var i = 0; i < N && answer; i++)
            {
                for (var j = 0; j < N && answer; j++)
                {
                    if (G[i][j] == '.') continue;
                    for (var k = 0; k < 4 && answer; k++)
                    {
                        var count = GetCount(i, j, k);
                        if (count > 9) answer = false;
                        else if (count >= 5)
                        {
                            if (G[i][j] == 'o')
                            {
                                a5++;
                                ca[i, j, k] = true;
                            }
                            else
                            {
                                b5++;
                                cb[i, j, k] = true;
                            }
                        }
                    }

                }
            }

            if (a5 > 0 && (b5 > 0 || a == b)) answer = false;

            bool CrossCheck(int h, int w)
            {
                var count = 0;
                for (var i = 0; i < N; i++)
                {
                    for (var j = 0; j < N; j++)
                    {
                        if (G[i][j] == '.') continue;
                        if (G[i][j] != G[h][w]) continue;
                        for (var k = 0; k < 4; k++)
                        {
                            if (G[i][j] == 'o')
                            {
                                if (ca[i, j, k] != ca[h, w, k]) count++;
                            }
                            else
                            {
                                if (cb[i, j, k] != cb[h, w, k]) count++;
                            }
                        }
                    }
                }

                return count <= 1;
            }

            if (answer)
            {
                (a5, b5) = (0, 0);
                for (var i = 0; i < N && answer; i++)
                {
                    for (var j = 0; j < N && answer; j++)
                    {
                        if (G[i][j] == '.') continue;
                        answer = CrossCheck(i, j);
                        var count = 0;
                        for (var k = 0; k < 4; k++)
                        {
                            if (G[i][j] == 'o')
                            {
                                if (ca[i, j, k]) count++;
                            }
                            else
                            {
                                if (cb[i, j, k]) count++;
                            }
                        }
                        if (count > 1)
                        {
                            if (G[i][j] == 'o') a5++;
                            else b5++;
                        }
                    }
                }
                if (a5 > 1 || b5 > 1) answer = false;
            }

            Console.WriteLine(answer ? "YES" : "NO");
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
