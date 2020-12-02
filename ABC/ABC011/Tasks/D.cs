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
            var (N, D) = Scanner.Scan<int, int>();
            var (X, Y) = Scanner.Scan<int, int>();
            if (X % D != 0 || Y % D != 0 || Math.Abs(X / D) + Math.Abs(Y / D) > N) { Console.WriteLine(0); return; }

            var nCk = new double[N + 1, N + 1];
            nCk[0, 0] = 1;
            for (var i = 1; i <= N; i++)
            {
                for (var j = 0; j <= i; j++)
                {
                    if (j == 0) nCk[i, j] = nCk[i - 1, j] / 2;
                    else nCk[i, j] = (nCk[i - 1, j - 1] + nCk[i - 1, j]) / 2;
                }
            }

            var answer = 0.0;
            X = Math.Abs(X / D);
            Y = Math.Abs(Y / D);
            for (var x = 0; x <= N; x++)
            {
                var y = N - x;
                if (x < X || y < Y) continue;
                if (x % 2 != X % 2 || y % 2 != Y % 2) continue;
                var px = (X + x) / 2;
                var py = (Y + y) / 2;
                answer += nCk[N, x] * nCk[x, px] * nCk[y, py];
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
