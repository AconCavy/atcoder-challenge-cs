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
            var S = Scanner.Scan<string>();
            var N = S.Length;
            const int inf = (int)1e9;
            var min = inf;
            var answer = new List<string>();
            const string T = "SHDC";
            var comp = (1 << 5) - 1;

            foreach (var m in T)
            {
                var count = 0;
                var state = 0;
                var tmp = new List<string>();
                var (l, r) = (0, 1);
                while (l < N)
                {
                    while (r < N && !T.Contains(S[r])) r++;
                    var s = S[l..r];
                    count++;
                    if (s[0] == m)
                    {
                        switch (s[1])
                        {
                            case '1': state |= 1 << 0; break;
                            case 'J': state |= 1 << 1; break;
                            case 'Q': state |= 1 << 2; break;
                            case 'K': state |= 1 << 3; break;
                            case 'A': state |= 1 << 4; break;
                            default: tmp.Add(s); break;
                        }
                    }
                    else
                    {
                        tmp.Add(s);
                    }

                    if (state == comp) break;

                    l = r;
                    r++;
                }

                if (state == comp && count < min)
                {
                    min = count;
                    answer = tmp;
                }
            }

            if (answer.Count == 0) Console.WriteLine(0);
            else Console.WriteLine(string.Join("", answer));
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
