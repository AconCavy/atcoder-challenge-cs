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
        public static void Main()
        {
            using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var (N, M, H, K) = Scanner.Scan<int, int, int, int>();
            var S = Scanner.Scan<string>();

            var items = new HashSet<(int X, int Y)>();
            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                items.Add((x, y));
            }

            (int Nx, int Ny) F(int x, int y, char c)
            {

                return c switch
                {
                    'R' => (x + 1, y),
                    'L' => (x - 1, y),
                    'U' => (x, y + 1),
                    'D' => (x, y - 1),
                    _ => (x, y),
                };
            }

            var (cx, cy) = (0, 0);
            foreach (var c in S)
            {
                (cx, cy) = F(cx, cy, c);
                H--;
                if (H < 0)
                {
                    Console.WriteLine("No");
                    return;
                }

                if (items.Contains((cx, cy)) && H < K)
                {
                    items.Remove((cx, cy));
                    H = K;
                }
            }

            Console.WriteLine("Yes");
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
