using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Tasks
{
    public class D
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
            var (H, W, A, B) = Scanner.Scan<int, int, int, int>();

            var answer = 0;
            var used = new bool[H, W];

            void Dfs(int ch, int cw, int a)
            {
                if (ch == H)
                {
                    if (a == A) answer++;
                    return;
                }

                if (a < A && !used[ch, cw])
                {
                    if (ch + 1 < H && !used[ch + 1, cw])
                    {
                        used[ch, cw] = used[ch + 1, cw] = true;
                        if (cw == W - 1) Dfs(ch + 1, 0, a + 1);
                        else Dfs(ch, cw + 1, a + 1);
                        used[ch, cw] = used[ch + 1, cw] = false;
                    }

                    if (cw + 1 < W && !used[ch, cw + 1])
                    {
                        used[ch, cw] = used[ch, cw + 1] = true;
                        if (cw == W - 1) Dfs(ch + 1, 0, a + 1);
                        else Dfs(ch, cw + 1, a + 1);
                        used[ch, cw] = used[ch, cw + 1] = false;
                    }
                }

                if (cw == W - 1) Dfs(ch + 1, 0, a);
                else Dfs(ch, cw + 1, a);
            }

            Dfs(0, 0, 0);

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
