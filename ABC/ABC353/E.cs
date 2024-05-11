using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

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
        var N = Scanner.Scan<int>();
        var S = Scanner.ScanEnumerable<string>().ToArray();
        var dict = new Dictionary<ulong, long>();
        var rhs = new RollingHash[N];
        for (var i = 0; i < N; i++)
        {
            rhs[i] = new RollingHash(S[i]);
        }

        long answer = 0;
        for (var i = 0; i < N; i++)
        {
            for (var k = 0; k < S[i].Length; k++)
            {
                var hash = rhs[i].SlicedHash(0, k + 1);
                if (!dict.ContainsKey(hash)) dict[hash] = 0;
                answer += dict[hash];
                dict[hash]++;
            }
        }

        Console.WriteLine(answer);
    }

    // https://qiita.com/keymoon/items/11fac5627672a6d6a9f6
    public class RollingHash
    {
        private const ulong Mask30 = (1UL << 30) - 1;
        private const ulong Mask31 = (1UL << 31) - 1;
        private const ulong Modulo = (1UL << 61) - 1;
        private const ulong Positivizer = Modulo * ((1UL << 3) - 1);
        public static readonly ulong Base;
        static RollingHash()
        {
            Base = (ulong)new Random().Next(1 << 8, int.MaxValue);
        }
        public readonly int Length;
        private readonly ulong[] _powers;
        private readonly ulong[] _hash;
        public RollingHash(ReadOnlySpan<char> s)
        {
            Length = s.Length;
            _powers = new ulong[Length + 1];
            _powers[0] = 1;
            _hash = new ulong[Length + 1];
            for (var i = 0; i < Length; i++)
            {
                _powers[i + 1] = CalcModulo(Multiply(_powers[i], Base));
                _hash[i + 1] = CalcModulo(Multiply(_hash[i], Base) + s[i]);
            }
        }
        public ulong SlicedHash(int start, int length)
        {
            if (start < 0 || start > Length) throw new ArgumentOutOfRangeException(nameof(start));
            if (start + length > Length) throw new ArgumentOutOfRangeException(nameof(length));
            return CalcModulo(_hash[start + length] + Positivizer - Multiply(_hash[start], _powers[length]));
        }
        private static ulong Multiply(ulong a, ulong b)
        {
            var au = a >> 31;
            var ad = a & Mask31;
            var bu = b >> 31;
            var bd = b & Mask31;
            var m = ad * bu + au * bd;
            var mu = m >> 30;
            var md = m & Mask30;
            return ((au * bu) << 1) + mu + (md << 31) + ad * bd;
        }
        private static ulong CalcModulo(ulong v)
        {
            var vu = v >> 61;
            var vd = v & Modulo;
            var x = vu + vd;
            return x < Modulo ? x : x - Modulo;
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
