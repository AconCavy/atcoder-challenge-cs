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
            var T = Scanner.Scan<string>();
            var c1 = new int[26];
            var c2 = new int[26];

            for (var i = 0; i < N; i++)
            {
                c1[T[N - 1 - i] - 'a']++;
                c2[T[i] - 'a']++;
            }

            {
                var s1 = T[N..];
                var s2 = new string(T[..N].Reverse().ToArray());
                if (s1 == s2)
                {
                    Console.WriteLine(s1);
                    Console.WriteLine(0);
                    return;
                }
            }

            for (var k = 0; k < N; k++)
            {
                c1[T[k] - 'a']++;
                c2[T[k] - 'a']--;
                c1[T[k + N] - 'a']--;
                c2[T[k + N] - 'a']++;
                var ok = true;
                for (var i = 0; i < 26; i++)
                {
                    ok &= c1[i] == c2[i];
                }

                if (!ok) continue;

                var s1 = T[..(k + 1)] + T[(k + N + 1)..];
                var s2 = new string(T.Substring(k + 1, N).Reverse().ToArray());
                ok &= s1 == s2;
                if (ok)
                {
                    Console.WriteLine(s1);
                    Console.WriteLine(k + 1);
                    return;
                }
            }

            Console.WriteLine(-1);
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
