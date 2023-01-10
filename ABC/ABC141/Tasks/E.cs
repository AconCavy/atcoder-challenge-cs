using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            var S = Scanner.Scan<string>();
            var rh = new RollingHash(S);
            var len = 0;
            for (var l1 = 0; l1 < N; l1++)
            {
                for (var l2 = l1; l2 < N; l2++)
                {
                    while (l1 + len < l2 && l2 + len < N && rh.Slice(l1, len + 1) == rh.Slice(l2, len + 1))
                    {
                        len++;
                    }
                }
            }

            Console.WriteLine(len);
        }

        public class RollingHash
        {
            private const ulong Mask30 = (1UL << 30) - 1;
            private const ulong Mask31 = (1UL << 31) - 1;
            private const ulong Modulo = (1UL << 61) - 1;
            private const ulong Positivizer = Modulo * ((1UL << 3) - 1);
            private const int MaxPowerLength = (int)5e3;
            private static readonly ulong[] Powers = new ulong[MaxPowerLength + 1];
            private static readonly ulong Base;

            static RollingHash()
            {
                Base = (ulong)new Random().Next(1 << 9, 1 << 30);
                Powers[0] = 1;
                for (var i = 0; i + 1 < Powers.Length; i++)
                {
                    Powers[i + 1] = CalcModulo(Multiply(Powers[i], Base));
                }
            }

            private readonly ulong[] _hash;

            public RollingHash(ReadOnlySpan<char> s)
            {
                _hash = new ulong[s.Length + 1];
                for (var i = 0; i < s.Length; i++)
                {
                    _hash[i + 1] = CalcModulo(Multiply(_hash[i], Base) + s[i]);
                }
            }

            public ulong Slice(int i, int length)
            {
                return CalcModulo(_hash[i + length] + Positivizer - Multiply(_hash[i], Powers[length]));
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
