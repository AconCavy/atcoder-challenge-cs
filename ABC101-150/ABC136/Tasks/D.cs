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
            var S = Scanner.Scan<string>();
            var N = S.Length;
            var distance = new int[N];
            for (var i = 0; i < N; i++)
            {
                if (i > 0 && S[i] == S[i - 1])
                {
                    if (S[i] == 'R') distance[i] = distance[i - 1] - 1;
                    else distance[i] = distance[i - 1] + 1;
                    continue;
                }
                var count = 0;
                var j = i;
                if (S[i] == 'R') while (S[j] == 'R') { j++; count++; }
                else while (S[j] == 'L') { j--; count++; }
                distance[i] = count;
            }

            var answer = new int[N];
            for (var i = 0; i < N; i++)
            {
                if (S[i] == 'R')
                {
                    if (distance[i] % 2 == 0) answer[i + distance[i]]++;
                    else answer[i + distance[i] - 1]++;
                }
                else
                {
                    if (distance[i] % 2 == 0) answer[i - distance[i]]++;
                    else answer[i - distance[i] + 1]++;
                }
            }

            Console.WriteLine(string.Join(" ", answer));
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
