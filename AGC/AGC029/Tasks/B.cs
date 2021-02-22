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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var dict = new Dictionary<long, long>();
            foreach (var a in A)
            {
                if (!dict.ContainsKey(a)) dict[a] = 0;
                dict[a]++;
            }

            Array.Sort(A, (x, y) => y.CompareTo(x));
            var answer = 0L;
            foreach (var a in A)
            {
                for (var t = 32; t >= 1; t--)
                {
                    var b = (1L << t) - a;
                    if (b <= 0 || !dict.ContainsKey(b)) continue;
                    if (b == a)
                    {
                        if (dict[b] > 1)
                        {
                            dict[b] -= 2;
                            answer++;
                        }
                    }
                    else
                    {
                        if (dict[a] > 0 && dict[b] > 0)
                        {
                            dict[a]--;
                            dict[b]--;
                            answer++;
                        }
                    }
                }
            }

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
