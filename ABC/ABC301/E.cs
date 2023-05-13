using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class E
    {
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (H, W, T) = Scanner.Scan<int, int, int>();
            var A = new char[H][];
            var G = new bool[H][];
            var (sh, sw) = (0, 0);
            var (gh, gw) = (0, 0);
            var map = new Dictionary<(int, int), int>();
            var M = 0;
            var snacks = new List<(int H, int W)>();
            for (var i = 0; i < H; i++)
            {
                A[i] = Scanner.Scan<string>().ToCharArray();
                G[i] = new bool[W];
                for (var j = 0; j < W; j++)
                {
                    if (A[i][j] == 'S') (sh, sw) = (i, j);
                    if (A[i][j] == 'G') (gh, gw) = (i, j);
                    if (A[i][j] == 'o')
                    {
                        map[(i, j)] = M++;
                        snacks.Add((i, j));
                    }
                    G[i][j] = A[i][j] != '#';
                }
            }

            var D4 = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

            int[][] GetDistance(int h, int w)
            {
                var result = new int[H][];
                for (var i = 0; i < H; i++)
                {
                    result[i] = new int[W];
                    for (var j = 0; j < W; j++)
                    {
                        result[i][j] = -1;
                    }
                }

                result[h][w] = 0;
                var queue = new Queue<(int, int)>();
                queue.Enqueue((h, w));
                while (queue.Count > 0)
                {
                    var (ch, cw) = queue.Dequeue();
                    foreach (var (dh, dw) in D4)
                    {
                        var (nh, nw) = (ch + dh, cw + dw);
                        if (nh < 0 || H <= nh || nw < 0 || W <= nw) continue;
                        if (!G[nh][nw] || result[nh][nw] != -1) continue;
                        result[nh][nw] = result[ch][cw] + 1;
                        queue.Enqueue((nh, nw));
                    }
                }

                return result;
            }

            var startToGoal = GetDistance(sh, sw)[gh][gw];
            if (startToGoal > T || startToGoal == -1)
            {
                Console.WriteLine(-1);
                return;
            }

            var snackDistances = new int[M][][];
            for (var k = 0; k < M; k++)
            {
                var snack = snacks[k];
                snackDistances[k] = GetDistance(snack.H, snack.W);
            }

            var dp = new int[M, 1 << M];
            const int Inf = (int)1e9;
            for (var i = 0; i < M; i++)
            {
                for (var j = 0; j < 1 << M; j++)
                {
                    dp[i, j] = Inf;
                }
            }

            var queue = new PriorityQueue<(int U, int S, int D)>((x, y) => x.D.CompareTo(y.D));
            for (var u = 0; u < M; u++)
            {
                var d = snackDistances[u][sh][sw];
                if (d == -1) continue;
                var s = 1 << u;
                dp[u, s] = d;
                queue.Enqueue((u, s, d));
            }

            while (queue.Count > 0)
            {
                var (u, cs, cd) = queue.Dequeue();
                if (dp[u, cs] < cd) continue;
                for (var v = 0; v < M; v++)
                {
                    if ((cs >> v & 1) == 1) continue;
                    var (nh, nw) = snacks[v];
                    var d = snackDistances[u][nh][nw];
                    if (d == -1) continue;
                    var nd = cd + d;
                    var ns = cs | (1 << v);
                    if (nd > T || dp[v, ns] <= nd) continue;
                    dp[v, ns] = nd;
                    queue.Enqueue((v, ns, nd));
                }
            }

            var answer = 0;
            for (var u = 0; u < M; u++)
            {
                for (var s = 0; s < 1 << M; s++)
                {
                    if (dp[u, s] == Inf || snackDistances[u][gh][gw] == -1) continue;
                    var gd = dp[u, s] + snackDistances[u][gh][gw];
                    if (gd <= T)
                    {
                        var count = 0;
                        for (var i = 0; i < M; i++)
                        {
                            count += (s >> i) & 1;
                        }

                        answer = Math.Max(answer, count);
                    }
                }
            }

            Console.WriteLine(answer);
        }

        public class PriorityQueue<T> : IReadOnlyCollection<T>
        {
            private readonly Comparison<T> _comparison;
            private readonly List<T> _heap;
            public PriorityQueue(IEnumerable<T> items, IComparer<T> comparer = null) : this(comparer)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IEnumerable<T> items, Comparison<T> comparison) : this(comparison)
            {
                foreach (var item in items) Enqueue(item);
            }
            public PriorityQueue(IComparer<T> comparer = null) : this((comparer ?? Comparer<T>.Default).Compare) { }
            public PriorityQueue(Comparison<T> comparison)
            {
                _heap = new List<T>();
                _comparison = comparison;
            }
            public int Count => _heap.Count;
            public IEnumerator<T> GetEnumerator() => _heap.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
            public void Enqueue(T item)
            {
                var child = Count;
                _heap.Add(item);
                while (child > 0)
                {
                    var parent = (child - 1) / 2;
                    if (_comparison(_heap[parent], _heap[child]) <= 0) break;
                    (_heap[parent], _heap[child]) = (_heap[child], _heap[parent]);
                    child = parent;
                }
            }
            public T Dequeue()
            {
                if (Count == 0) throw new InvalidOperationException();
                var result = _heap[0];
                _heap[0] = _heap[Count - 1];
                _heap.RemoveAt(Count - 1);
                var parent = 0;
                while (parent * 2 + 1 < Count)
                {
                    var left = parent * 2 + 1;
                    var right = parent * 2 + 2;
                    if (right < Count && _comparison(_heap[left], _heap[right]) > 0)
                        left = right;
                    if (_comparison(_heap[parent], _heap[left]) <= 0) break;
                    (_heap[parent], _heap[left]) = (_heap[left], _heap[parent]);
                    parent = left;
                }
                return result;
            }
            public T Peek()
            {
                if (Count == 0) throw new InvalidOperationException();
                return _heap[0];
            }
            public bool TryDequeue(out T result)
            {
                if (Count > 0)
                {
                    result = Dequeue();
                    return true;
                }
                result = default;
                return false;
            }
            public bool TryPeek(out T result)
            {
                if (Count > 0)
                {
                    result = Peek();
                    return true;
                }
                result = default;
                return false;
            }
            public void Clear() => _heap.Clear();
            public bool Contains(T item) => _heap.Contains(item);
        }

        public static class Printer
        {
            public static void Print<T>(T source) => Console.WriteLine(source);
            public static void Print1D<T>(IEnumerable<T> source, string separator = "") => Console.WriteLine(string.Join(separator, source));
            public static void Print1D<T, U>(IEnumerable<T> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(separator, source.Select(selector)));
            public static void Print2D<T>(IEnumerable<IEnumerable<T>> source, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x))));
            public static void Print2D<T, U>(IEnumerable<IEnumerable<T>> source, Func<T, U> selector, string separator = "") => Console.WriteLine(string.Join(Environment.NewLine, source.Select(x => string.Join(separator, x.Select(selector)))));
            public static void Print2D<T>(T[,] source, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(source[i, j]);
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
            public static void Print2D<T, U>(T[,] source, Func<T, U> selector, string separator = "")
            {
                var (h, w) = (source.GetLength(0), source.GetLength(1));
                for (var i = 0; i < h; i++)
                {
                    for (var j = 0; j < w; j++)
                    {
                        Console.Write(selector(source[i, j]));
                        Console.Write(j == w - 1 ? Environment.NewLine : separator);
                    }
                }
            }
        }

        public static class Scanner
        {
            public static T Scan<T>() where T : IConvertible => Convert<T>(Scan()[0]);
            public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]));
            }
            public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]));
            }
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]));
            }
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]));
            }
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
            {
                var buffer = Scan();
                return (Convert<T1>(buffer[0]), Convert<T2>(buffer[1]), Convert<T3>(buffer[2]), Convert<T4>(buffer[3]), Convert<T5>(buffer[4]), Convert<T6>(buffer[5]));
            }
            public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => Scan().Select(Convert<T>);
            private static string[] Scan()
            {
                var line = Console.ReadLine()?.Trim() ?? string.Empty;
                return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
            }
            private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
        }
    }
}
