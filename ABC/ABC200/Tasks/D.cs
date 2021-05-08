using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().Select(x => x % 200).ToArray();

            void Print(IEnumerable<int> x, IEnumerable<int> y)
            {
                Console.WriteLine("Yes");

                void Inner(IEnumerable<int> source)
                {
                    Console.Write(source.Count());
                    Console.Write(" ");
                    Console.WriteLine(string.Join(" ", source.Select(e => e + 1)));
                }

                Inner(x);
                Inner(y);
            }

            var dp = new List<int>[200].Select(_ => new List<int>()).ToArray();
            var max = Math.Min(N, 8);
            for (var i = 0; i < 1 << max; i++)
            {
                var sum = 0;
                var tmp = new List<int>();
                for (var j = 0; j < max; j++)
                {
                    if ((i >> j & 1) == 1)
                    {
                        tmp.Add(j);
                        sum += A[j];
                        sum %= 200;
                    }
                }

                if (dp[sum].Any())
                {
                    Print(dp[sum], tmp);
                    return;
                }

                dp[sum] = tmp;
            }

            Console.WriteLine("No");
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
