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
        public static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var T = Scanner.Scan<int>();

            long Adjust(ref long X, ref long Y)
            {
                var d = Math.Abs(X - Y);
                if (X < Y)
                {
                    X += d / 3 * 2;
                    Y -= d / 3;
                }
                else
                {
                    X -= d / 3;
                    Y += d / 3 * 2;
                }

                return d / 3;
            }

            while (T-- > 0)
            {
                var A = Scanner.ScanEnumerable<long>().ToArray();
                Array.Sort(A);
                var (R, G, B) = (A[0], A[1], A[2]);
                var answer = 0L;

                if (Math.Abs(R - G) % 3 == 0)
                {
                    answer += Adjust(ref R, ref G);
                    B -= answer;
                }
                else if (Math.Abs(G - B) % 3 == 0)
                {
                    answer += Adjust(ref G, ref B);
                    R -= answer;
                }
                else if (Math.Abs(R - B) % 3 == 0)
                {
                    answer += Adjust(ref R, ref B);
                    G -= answer;
                }
                else
                {
                    Console.WriteLine(-1);
                    continue;
                }

                if (R == G || R == B)
                {
                    answer += R;
                }
                else if (G == B)
                {
                    answer += G;
                }
                else
                {
                    answer = -1;
                }

                Console.WriteLine(answer);
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
                return (T)Convert.ChangeType(queue.Dequeue(), typeof(T));
            }
            public static T Scan<T>() => Next<T>();
            public static (T1, T2) Scan<T1, T2>() => (Next<T1>(), Next<T2>());
            public static (T1, T2, T3) Scan<T1, T2, T3>() => (Next<T1>(), Next<T2>(), Next<T3>());
            public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>());
            public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>());
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
