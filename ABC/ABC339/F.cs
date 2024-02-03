using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Tasks;

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
        var M = 2001;
        var A = new string[N].Select(_ => Scanner.Scan<string>()).ToArray();
        var B = new string[N];
        for (var i = 0; i < N; i++)
        {
            var tmp = A[i].ToCharArray();
            var buffer = new char[M];
            Array.Fill(buffer, '0');
            for (var j = 0; j < tmp.Length; j++)
            {
                buffer[j] = tmp[tmp.Length - 1 - j];
            }
            B[i] = new string(buffer);
        }


        var dict = new Dictionary<string, long>();
        for (var i = 0; i < N; i++)
        {
            if (!dict.ContainsKey(B[i])) dict[B[i]] = 0;
            dict[B[i]]++;
        }


        string F(string x, string y)
        {
            var buffer = new int[M];
            for (var i = 0; i < x.Length; i++)
            {
                for (var j = 0; j < y.Length; j++)
                {
                    var a = x[i] - '0';
                    var b = y[j] - '0';
                    var c = (a * b);
                    var k = 0;
                    while (c > 0)
                    {
                        buffer[i + j + k] += c % 10;
                        c /= 10;
                        k++;
                    }
                }
            }


            for (var i = 0; i + 1 < M; i++)
            {
                var r = buffer[i] / 10;
                buffer[i + 1] += r;
                buffer[i] %= 10;
            }

            return string.Join("", buffer);
        }

        B = B.Distinct().ToArray();
        long answer = 0;
        for (var i = 0; i < B.Length; i++)
        {
            for (var j = 0; j < B.Length; j++)
            {
                var x = F(B[i], B[j]);
                if (dict.ContainsKey(x))
                {
                    var a = dict[B[i]];
                    var b = dict[B[j]];
                    answer += a * b * dict[x];
                }
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
