using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class D
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var N = Scanner.Scan<int>();
            // 75, 25 * 3, 15 * 5, 3 * 5 * 5
            var e = new int[N + 1];
            for (var i = 2; i <= N; i++)
            {
                var x = i;
                for (var j = 2; j <= i; j++)
                {
                    while (x % j == 0)
                    {
                        e[j]++;
                        x /= j;
                    }
                }
            }

            var (c3, c5, c15, c25, c75) = (0, 0, 0, 0, 0);
            foreach (var c in e)
            {
                if (c >= 2) c3++;
                if (c >= 4) c5++;
                if (c >= 14) c15++;
                if (c >= 24) c25++;
                if (c >= 74) c75++;
            }

            var answer = c75;
            answer += c25 * (c3 - 1);
            answer += c15 * (c5 - 1);
            answer += c5 * (c5 - 1) * (c3 - 2) / 2;

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
