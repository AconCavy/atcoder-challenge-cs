using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var S = Scanner.Scan<string>();
            if (N <= 2) { Console.WriteLine(1); return; }
            var hashset = new HashSet<string>();
            for (var i = 0; i + 1 < N; i++) hashset.Add(new string(new[] { S[i], S[i + 1] }));
            var sc = hashset.ToArray();
            if (sc.Length == 1)
            {
                Console.WriteLine((N + 1) / 2);
                return;
            }
            var answer = N;
            for (var i = 0; i < sc.Length - 1; i++)
            {
                for (var j = i + 1; j < sc.Length; j++)
                {
                    var count = 0;
                    for (var k = 0; k < S.Length; k++)
                    {
                        count++;
                        if (k + 1 < S.Length)
                        {
                            if (S[k] == sc[i][0] && S[k + 1] == sc[i][1] ||
                            S[k] == sc[j][0] && S[k + 1] == sc[j][1])
                                k++;
                        }
                    }
                    answer = Math.Min(answer, count);
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
