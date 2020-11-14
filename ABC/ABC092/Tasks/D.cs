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
            var (A, B) = Scanner.Scan<int, int>();
            const int K = 50;
            const int K2 = K * 2;
            var G = new char[K2][].Select(_ => new char[K2]).ToArray();
            for (var i = 0; i < K2; i++)
            {
                var c = i < K ? '#' : '.';
                for (var j = 0; j < K2; j++) G[i][j] = c;
            }
            for (var i = 0; i < K2 && (A > 1 || B > 1); i += 2)
            {
                for (var j = 0; j < K2 && (A > 1 || B > 1); j += 2)
                {
                    if (A > 1)
                    {
                        G[i][j] = '.';
                        A--;
                    }
                    if (B > 1)
                    {
                        G[K2 - 1 - i][j] = '#';
                        B--;
                    }
                }
            }

            Console.WriteLine($"{K2} {K2}");
            Console.WriteLine(string.Join("\n", G.Select(x => new string(x))));
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
