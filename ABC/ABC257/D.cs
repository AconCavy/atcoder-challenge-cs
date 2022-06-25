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
            var N = Scanner.Scan<int>();
            var Ramps = new Ramp[N];
            for (var i = 0; i < N; i++)
            {
                var (x, y, p) = Scanner.Scan<long, long, long>();
                Ramps[i] = new Ramp(x, y, p);
            }

            bool CanMove(Ramp from, Ramp to, long s)
            {
                return from.P * s >= Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
            }

            const long inf = (long)4e9;
            var answer = inf;
            for (var k = 0; k < N; k++)
            {
                bool F(long s)
                {
                    var queue = new Queue<Ramp>();
                    var used = new bool[N];

                    used[k] = true;
                    queue.Enqueue(Ramps[k]);

                    while (queue.Count > 0)
                    {
                        var u = queue.Dequeue();
                        for (var i = 0; i < N; i++)
                        {
                            if (!used[i] && CanMove(u, Ramps[i], s))
                            {
                                used[i] = true;
                                queue.Enqueue(Ramps[i]);
                            }
                        }
                    }

                    return used.All(x => x);
                }

                var s = BinarySearch(-1, inf, F);
                answer = Math.Min(answer, s);
            }

            Console.WriteLine(answer);
        }

        public readonly struct Ramp
        {
            public readonly long X;
            public readonly long Y;
            public readonly long P;
            public Ramp(long x, long y, long p) => (X, Y, P) = (x, y, p);

        }

        public static long BinarySearch(long ng, long ok, Func<long, bool> func)
        {
            while (Math.Abs(ok - ng) > 1)
            {
                var m = (ok + ng) / 2;
                if (func(m)) ok = m;
                else ng = m;
            }
            return ok;
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
