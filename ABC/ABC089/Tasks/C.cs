using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var S = new string[N];
            var MARCH = new long[5];
            var answer = 0L;
            for (var i = 0; i < S.Length; i++)
            {
                S[i] = Scanner.Scan<string>();
                switch (S[i][0])
                {
                    case 'M': MARCH[0]++; break;
                    case 'A': MARCH[1]++; break;
                    case 'R': MARCH[2]++; break;
                    case 'C': MARCH[3]++; break;
                    case 'H': MARCH[4]++; break;
                }
            }

            for (var i = 0; i < 3; i++)
            {
                for (var j = i + 1; j < 4; j++)
                {
                    for (var k = j + 1; k < 5; k++)
                    {
                        if (MARCH[i] > 0 && MARCH[j] > 0 && MARCH[k] > 0)
                        {
                            answer += MARCH[i] * MARCH[j] * MARCH[k];
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
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}
