using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var N = Scanner.Scan<int>();
            var S = Scanner.Scan<string>();
            // AARCC -> R, other-> AC
            var aarcc = new Queue<int>();
            var arc = new Queue<int>();
            for (var i = 0; i < N; i++)
            {
                if (S[i] != 'R') continue;
                var d = 0;
                while (i - d - 1 >= 0 && i + d + 1 < N)
                {
                    if (S[i - d - 1] == 'A' && S[i + d + 1] == 'C') d++;
                    else break;
                }

                if (d == 1) arc.Enqueue(3);
                if (d > 1) aarcc.Enqueue(d * 2 + 1);
            }

            var answer = 0;
            while (true)
            {
                if (answer % 2 == 0)
                {
                    if (aarcc.Count > 0)
                    {
                        var x = aarcc.Dequeue();
                        answer++;
                        if (x == 5) arc.Enqueue(x);
                        else aarcc.Enqueue(x - 2);
                    }
                    else if (arc.Count > 0)
                    {
                        arc.Dequeue();
                        answer++;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    if (arc.Count > 0)
                    {
                        arc.Dequeue();
                        answer++;

                    }
                    else if (aarcc.Count > 0)
                    {
                        aarcc.Dequeue();
                        answer++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(answer);
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
