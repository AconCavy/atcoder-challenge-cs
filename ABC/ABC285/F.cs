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
            var S = Scanner.Scan<string>().Select(x => x - 'a').ToArray();
            var Q = Scanner.Scan<int>();
            var fts = new FenwickTree[26].Select(_ => new FenwickTree(N)).ToArray();
            var sc = new int[26];
            for (var i = 0; i < N; i++)
            {
                var c = S[i];
                sc[c]++;
                fts[c].Add(i, 1);
            }

            while (Q-- > 0)
            {
                var query = Scanner.ScanEnumerable<string>().ToArray();
                if (query[0] == "1")
                {
                    var (x, c) = (int.Parse(query[1]) - 1, query[2][0] - 'a');
                    var p = S[x];
                    S[x] = c;
                    fts[p].Add(x, -1);
                    fts[c].Add(x, 1);
                    sc[p]--;
                    sc[c]++;
                }
                else
                {
                    var (l, r) = (int.Parse(query[1]) - 1, int.Parse(query[2]));
                    var tc = new int[26];
                    for (var i = 0; i < 26; i++)
                    {
                        tc[i] = (int)fts[i].Sum(l, r);
                    }

                    var alpha = 0;
                    var ll = l;
                    var answer = true;
                    while (alpha < 26 && tc[alpha] == 0) alpha++;

                    if (alpha < 26)
                    {
                        ll += tc[alpha];
                        alpha++;
                    }

                    while (answer && alpha < 26 && ll + tc[alpha] <= r)
                    {
                        var rr = ll + tc[alpha];
                        if (rr < r)
                        {
                            answer &= sc[alpha] == tc[alpha];
                        }
                        else
                        {
                            answer &= sc[alpha] >= tc[alpha];
                        }

                        answer &= tc[alpha] == fts[alpha].Sum(ll, rr);
                        ll = rr;
                        alpha++;
                    }

                    Console.WriteLine(answer ? "Yes" : "No");
                }
            }
        }

        public class FenwickTree
        {
            public int Length { get; }
            private readonly long[] _data;
            public FenwickTree(int length)
            {
                if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));
                Length = length;
                _data = new long[length];
            }
            public void Add(int index, long value)
            {
                if (index < 0 || Length <= index) throw new ArgumentOutOfRangeException(nameof(index));
                index++;
                while (index <= Length)
                {
                    _data[index - 1] += value;
                    index += index & -index;
                }
            }
            public long Sum(int length)
            {
                if (length < 0 || Length < length) throw new ArgumentOutOfRangeException(nameof(length));
                var s = 0L;
                while (length > 0)
                {
                    s += _data[length - 1];
                    length -= length & -length;
                }
                return s;
            }
            public long Sum(int left, int right)
            {
                if (left < 0 || right < left || Length < right) throw new ArgumentOutOfRangeException();
                return Sum(right) - Sum(left);
            }
            public int LowerBound(long value) => Bound(value, (x, y) => x <= y);
            public int UpperBound(long value) => Bound(value, (x, y) => x < y);
            private int Bound(long value, Func<long, long, bool> compare)
            {
                if (Length == 0 || compare(value, _data[0])) return 0;
                var x = 0;
                var r = 1;
                while (r < Length) r <<= 1;
                for (var k = r; k > 0; k >>= 1)
                {
                    if (x + k - 1 >= Length || compare(value, _data[x + k - 1])) continue;
                    value -= _data[x + k - 1];
                    x += k;
                }
                return x;
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
