using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
    {
        public static void Main()
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            const int N = 7;
            var S = Scanner.Scan<string>();

            int F(char c)
            {
                return c switch
                {
                    'a' => 0,
                    't' => 1,
                    'c' => 2,
                    'o' => 3,
                    'd' => 4,
                    'e' => 5,
                    'r' => 6,
                    _ => 7,
                };
            }

            var T = S.Select(x => F(x)).ToArray();
            var ft = new FenwickTree(10);
            var answer = 0L;
            for (var i = 0; i < N; i++)
            {
                var c = T[i];
                answer += i - ft.Sum(c + 1);
                ft.Add(c, 1);
            }

            Console.WriteLine(answer);
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
