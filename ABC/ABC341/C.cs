using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var (H, W, N) = Scanner.Scan<int, int, int>();
        var T = Scanner.Scan<string>();
        var G = new char[H][];
        for (var i = 0; i < H; i++)
        {
            G[i] = Scanner.Scan<string>().ToCharArray();
        }

        (int dh, int dw) Delta(char d)
        {
            return d switch
            {
                'L' => (0, -1),
                'R' => (0, 1),
                'U' => (-1, 0),
                'D' => (1, 0),
                _ => (0, 0)
            };
        }

        (int h, int w) F(int ch, int cw)
        {
            foreach (var d in T)
            {
                var (dh, dw) = Delta(d);
                var (nh, nw) = (ch + dh, cw + dw);
                if (nh < 0 || H <= nh || nw < 0 || W <= nw) return (-1, -1);
                if (G[nh][nw] == '#') return (-1, -1);
                ch = nh;
                cw = nw;
            }

            return (ch, cw);
        }

        var ok = new bool[H, W];
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                if (G[i][j] == '#') continue;
                var (ch, cw) = F(i, j);
                if (ch < 0 || cw < 0) continue;
                ok[ch, cw] = true;
            }
        }

        var answer = 0;
        for (var i = 0; i < H; i++)
        {
            for (var j = 0; j < W; j++)
            {
                if (G[i][j] == '#') continue;
                if (ok[i, j]) answer++;
            }
        }

        Console.WriteLine(answer);
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
