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
            var (N, K) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<int>().Select(x => x - 1).ToArray();
            var dict = new Dictionary<int, int>();
            var current = 0;
            var loopStart = -1;
            var loopEnd = -1;
            var order = new List<int>();
            for (var i = 0; i <= K; i++)
            {
                if (dict.ContainsKey(current))
                {
                    loopStart = dict[current];
                    loopEnd = i;
                    break;
                }
                order.Add(current + 1);
                dict[current] = i;
                current = A[current];
            }

            if (loopStart == -1)
            {
                Console.WriteLine(order.Last());
                return;
            }


            K -= loopStart;
            K %= loopEnd - loopStart;
            var answer = order[loopStart + (int)K];
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
