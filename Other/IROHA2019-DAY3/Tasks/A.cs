using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class A
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
            var alpha = Scanner.ScanEnumerable<long>().ToArray();

            var (A, B) = (alpha[0], alpha[1]);
            var answer = A - B;
            Console.WriteLine(answer);

            var (C, D) = (alpha[2], alpha[3]);
            answer = C + D;
            Console.WriteLine(answer);

            var (E, F) = (alpha[4], alpha[5]);
            answer = Math.Max(0, F + 1 - E);
            Console.WriteLine(answer);

            var (G, H, I) = (alpha[6], alpha[7], alpha[8]);
            answer = (G + H + I) / 3 + 1;
            Console.WriteLine(answer);

            var J = (int)alpha[9];
            const string dagabaji = "dagabaji";
            var ansstr = dagabaji;
            var comparer = StringComparer.OrdinalIgnoreCase;

            void Dfs(int idx, string curr)
            {
                if (curr.Length == J)
                {
                    if (comparer.Compare(curr, ansstr) < 0) ansstr = curr;
                    return;
                }

                for (var i = idx + 1; i < dagabaji.Length; i++)
                {
                    Dfs(i, curr + dagabaji[i]);
                }
            }

            Dfs(-1, "");
            Console.WriteLine(ansstr);

            var (K, L, M, N) = (alpha[10], alpha[11], alpha[12], alpha[13]);
            const long inf = (long)1e18;
            var (ans1, ans2) = (0L, inf);
            // 59x + k = 61y + l;
            // 59x - 61y + k - l = 0;
            // 59x + k - l = 61y;
            var order = 0;
            for (var i = 0; ; i++)
            {
                var j = 59L * i + K - L;
                if (j % 61 == 0)
                {
                    order++;
                    if (order == M)
                    {
                        ans1 = 59L * i + K;
                        break;
                    }
                }
            }
            var complete = new[] { 6, 28, 496, 8128, 33550336 };
            foreach (var x in complete)
            {
                if (Math.Abs(ans1 - x) >= N) ans2 = Math.Min(ans2, x);
            }

            Console.WriteLine(Math.Min(ans1, ans2));
            Console.WriteLine(Math.Max(ans1, ans2));

            var (O, P, Q) = (alpha[14], alpha[15], alpha[16]);
            var (R, S, T) = (alpha[17], alpha[18], alpha[19]);
            var (U, V, W) = (alpha[20], alpha[21], alpha[22]);
            var (X, Y, Z) = (alpha[23], alpha[24], alpha[25]);
            const long mod = 9973;
            answer = (O + P + Q) % mod;
            answer = (R + S + T) % mod * answer % mod;
            answer = (U + V + W) % mod * answer % mod;
            answer = (X + Y + Z) % mod * answer % mod;
            Console.WriteLine(answer);
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (!queue.Any()) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
