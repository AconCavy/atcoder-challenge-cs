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
            var T = Scanner.Scan<int>();
            var answer = new long[T];
            for (var i = 0; i < T; i++)
            {
                var (N, M, A, B) = Scanner.Scan<int, int, int, int>();
                answer[i] = FloorSum(N, M, A, B);
            }
            foreach (var ans in answer)
            {
                Console.WriteLine(ans);
            }
        }

        public static long FloorSum(long n, long m, long a, long b)
        {
            var ret = 0L;
            if (a >= m)
            {
                ret += (n - 1) * n * (a / m) / 2;
                a %= m;
            }

            if (b >= m)
            {
                ret += n * (b / m);
                b %= m;
            }

            var yMax = (a * n + b) / m;
            var xMax = yMax * m - b;
            if (yMax == 0) return ret;
            ret += (n - (xMax + a - 1) / a) * yMax;
            ret += FloorSum(yMax, a, m, (a - xMax % a) % a);
            return ret;
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
