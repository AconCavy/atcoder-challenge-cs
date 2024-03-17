using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class D
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
        var (N, H, W) = Scanner.Scan<int, int, int>();
        var T = new (int A, int B)[N];
        for (var i = 0; i < N; i++)
        {
            var (a, b) = Scanner.Scan<int, int>();
            T[i] = (a, b);
        }

        var G = new bool[H, W];

        bool Dfs((int A, int B)[] tiles, int k)
        {
            var result = true;
            for (var i = 0; i < H && result; i++)
            {
                for (var j = 0; j < W && result; j++)
                {
                    result &= G[i, j];
                }
            }

            if (k >= N || result) return result;

            if (Dfs(tiles, k + 1)) return true;

            var (a, b) = tiles[k];
            for (var t = 0; t < 2; t++)
            {
                var end = false;
                for (var h = 0; h + a <= H && !end; h++)
                {
                    for (var w = 0; w + b <= W && !end; w++)
                    {
                        if (G[h, w]) continue;

                        var ok = true;
                        for (var i = 0; i < a && ok; i++)
                        {
                            for (var j = 0; j < b && ok; j++)
                            {
                                ok &= !G[h + i, w + j];
                            }
                        }

                        if (!ok) continue;

                        for (var i = 0; i < a; i++)
                        {
                            for (var j = 0; j < b; j++)
                            {
                                G[h + i, w + j] = true;
                            }
                        }

                        if (Dfs(tiles, k + 1)) return true;

                        for (var i = 0; i < a; i++)
                        {
                            for (var j = 0; j < b; j++)
                            {
                                G[h + i, w + j] = false;
                            }
                        }

                        end = true;
                    }
                }

                if (a == b) break;
                (a, b) = (b, a);
            }

            return false;
        }

        var tiles = new (int A, int B)[N];
        foreach (var order in Permutation.Generate(N))
        {
            for (var i = 0; i < N; i++)
            {
                tiles[i] = T[order[i]];
            }

            if (Dfs(tiles, 0))
            {
                Console.WriteLine("Yes");
                return;
            }
        }

        Console.WriteLine("No");
    }

    public static class Permutation
    {
        public static bool NextPermutation(Span<int> indices)
        {
            var n = indices.Length;
            var (i, j) = (n - 2, n - 1);
            while (i >= 0 && indices[i] >= indices[i + 1]) i--;
            if (i == -1) return false;
            while (j > i && indices[j] <= indices[i]) j--;
            (indices[i], indices[j]) = (indices[j], indices[i]);
            indices[(i + 1)..].Reverse();
            return true;
        }
        public static bool PreviousPermutation(Span<int> indices)
        {
            var n = indices.Length;
            var (i, j) = (n - 2, n - 1);
            while (i >= 0 && indices[i] <= indices[i + 1]) i--;
            if (i == -1) return false;
            indices[(i + 1)..].Reverse();
            while (j > i && indices[j - 1] < indices[i]) j--;
            (indices[i], indices[j]) = (indices[j], indices[i]);
            return true;
        }
        public static IEnumerable<IReadOnlyList<int>> Generate(int n)
        {
            return Inner();
            IEnumerable<IReadOnlyList<int>> Inner()
            {
                var indices = new int[n];
                for (var i = 0; i < indices.Length; i++) indices[i] = i;
                do { yield return indices; } while (NextPermutation(indices));
            }
        }
        public static IEnumerable<IReadOnlyList<int>> GenerateDescending(int n)
        {
            return Inner();
            IEnumerable<IReadOnlyList<int>> Inner()
            {
                var indices = new int[n];
                for (var i = 0; i < indices.Length; i++) indices[i] = n - 1 - i;
                do { yield return indices; } while (PreviousPermutation(indices));
            }
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
