using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class V
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
        var (N, M) = Scanner.Scan<int, int>();
        var rerooting = new ReRooting<long>(N, new Operation(M));
        for (var i = 0; i < N - 1; i++)
        {
            var (x, y) = Scanner.Scan<int, int>();
            x--; y--;
            rerooting.AddEdge(x, y);
        }

        var answer = rerooting.Calc();
        Console.WriteLine(string.Join(Environment.NewLine, answer.Select(x => (x - 1 + M) % M)));
    }

    public class Operation : ReRooting<long>.IOperation
    {
        public readonly long Mod;
        public Operation(long mod) => Mod = mod;

        public long Identity => 1;

        public long AddRoot(long value)
        {
            return (value + 1) % Mod;
        }

        public long Merge(long left, long right)
        {
            return left * right % Mod;
        }
    }

    public class ReRooting<T>
    {
        public int Size { get; init; }
        private readonly List<int>[] _edges;
        private readonly IOperation _operation;

        public ReRooting(int size, IOperation operation)
        {
            Size = size;
            _operation = operation;
            _edges = new List<int>[Size];
            for (var i = 0; i < Size; i++) _edges[i] = new List<int>();
        }

        public void AddEdge(int u, int v)
        {
            _edges[u].Add(v);
            _edges[v].Add(u);
        }

        public IReadOnlyList<T> Calc()
        {
            var result = new T[Size];
            Array.Fill(result, _operation.Identity);
            var dp = new T[Size][];

            Dfs(0);
            Bfs(0, _operation.Identity);
            return result;

            T Dfs(int u, int p = -1)
            {
                dp[u] = new T[_edges[u].Count];
                var cum = _operation.Identity;
                for (var i = 0; i < _edges[u].Count; i++)
                {
                    var v = _edges[u][i];
                    if (v == p) continue;
                    dp[u][i] = Dfs(v, u);
                    cum = _operation.Merge(cum, dp[u][i]);
                }

                return _operation.AddRoot(cum);
            }

            void Bfs(int u, T value, int p = -1)
            {
                var n = _edges[u].Count;
                for (var i = 0; i < n; i++)
                {
                    if (_edges[u][i] == p) dp[u][i] = value;
                }

                var cumL = new T[n + 1];
                var cumR = new T[n + 1];
                Array.Fill(cumL, _operation.Identity);
                Array.Fill(cumR, _operation.Identity);
                for (var i = 0; i < n; i++)
                {
                    var j = n - 1 - i;
                    cumL[i + 1] = _operation.Merge(cumL[i], dp[u][i]);
                    cumR[j] = _operation.Merge(cumR[j + 1], dp[u][j]);
                }

                result[u] = _operation.AddRoot(cumL[n]);

                for (var i = 0; i < n; i++)
                {
                    var v = _edges[u][i];
                    if (v != p) Bfs(v, _operation.AddRoot(_operation.Merge(cumL[i], cumR[i + 1])), u);
                }
            }
        }

        public interface IOperation
        {
            public T Identity { get; }
            public T Merge(T left, T right);
            public T AddRoot(T value);
        }
    }

    public static class Scanner
    {
        public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
        public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]));
        }
        public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
        }
        public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
        }
        public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
        }
        public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
        }
        public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
        private static string[] ScanStringArray()
        {
            var line = Console.ReadLine()?.Trim() ?? string.Empty;
            return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
        }
        private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
    }
}
