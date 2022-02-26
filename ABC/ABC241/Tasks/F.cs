using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var (H, W, N) = Scanner.Scan<int, int, int>();
            var s = Scanner.Scan<int, int>();
            var t = Scanner.Scan<int, int>();
            var dictP = new Dictionary<(int X, int Y), int>();
            var dxa = new Dictionary<int, List<int>>();
            var dya = new Dictionary<int, List<int>>();
            var dxd = new Dictionary<int, List<int>>();
            var dyd = new Dictionary<int, List<int>>();

            dictP[s] = 0;
            dictP[t] = -1;
            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            for (var i = 0; i < N; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                if (!dxd.ContainsKey(x)) dxa[x] = new List<int>();
                dxa[x].Add(y);
                if (!dyd.ContainsKey(y)) dya[y] = new List<int>();
                dya[y].Add(x);
                if (!dxd.ContainsKey(x)) dxd[x] = new List<int>();
                dxd[x].Add(y);
                if (!dyd.ContainsKey(y)) dyd[y] = new List<int>();
                dyd[y].Add(x);

                foreach (var (dx, dy) in D4)
                {
                    var (nx, ny) = (x + dx, y + dy);
                    if (nx <= 0 || H < nx || ny <= 0 || W < ny) continue;
                    dictP[(nx, ny)] = -1;
                }
            }

            foreach (var list in dxa.Values)
            {
                list.Sort();
            }

            foreach (var list in dya.Values)
            {
                list.Sort();
            }

            foreach (var list in dxd.Values)
            {
                list.Sort();
                list.Reverse();
            }

            foreach (var list in dyd.Values)
            {
                list.Sort();
                list.Reverse();
            }

            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue(s);

            void Enqueue((int, int) u, (int, int) v)
            {
                if (dictP.ContainsKey(v) && dictP[v] == -1)
                {
                    dictP[v] = dictP[u] + 1;
                    queue.Enqueue(v);
                }
            }

            while (queue.Count > 0)
            {
                var u = queue.Dequeue();

                if (dxd.ContainsKey(u.X))
                {
                    // U
                    var lb = UpperBound(dxd[u.X], u.Y, (x, y) => y.CompareTo(x));
                    if (lb < dxd[u.X].Count)
                    {
                        var v = (u.X, Y: dxd[u.X][lb] + 1);
                        Enqueue(u, v);
                    }
                }

                if (dxa.ContainsKey(u.X))
                {
                    // D
                    var lb = UpperBound(dxa[u.X], u.Y, (x, y) => x.CompareTo(y));
                    if (lb < dxa[u.X].Count)
                    {
                        var v = (u.X, Y: dxa[u.X][lb] - 1);
                        Enqueue(u, v);

                    }
                }

                if (dyd.ContainsKey(u.Y))
                {
                    // L
                    var lb = UpperBound(dyd[u.Y], u.X, (x, y) => y.CompareTo(x));
                    if (lb < dyd[u.Y].Count)
                    {
                        var v = (X: dyd[u.Y][lb] + 1, u.Y);
                        Enqueue(u, v);

                    }
                }

                if (dya.ContainsKey(u.Y))
                {
                    // D
                    var lb = UpperBound(dya[u.Y], u.X, (x, y) => x.CompareTo(y));
                    if (lb < dya[u.Y].Count)
                    {
                        var v = (X: dya[u.Y][lb] - 1, u.Y);
                        Enqueue(u, v);
                    }
                }
            }

            var answer = dictP[t];
            Console.WriteLine(answer);
        }

        public static int UpperBound<T>(List<T> source, T key, Comparison<T> comparison)
        {
            var (l, r) = (-1, source.Count);
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (comparison(source[m], key) > 0) r = m;
                else l = m;
            }
            return r;
        }

        public static class Scanner
        {
            public static string ScanLine() => Console.ReadLine()?.Trim() ?? string.Empty;
            public static string[] Scan() => ScanLine().Split(' ');
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var line = Scan();
                return (Convert<T1>(line[0]), Convert<T2>(line[1]), Convert<T3>(line[2]), Convert<T4>(line[3]), Convert<T5>(line[4]), Convert<T6>(line[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
