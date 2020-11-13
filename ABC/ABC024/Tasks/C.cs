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
            var (N, D, K) = Scanner.Scan<int, int, int>();
            var LR = new (int L, int R)[D];
            for (var i = 0; i < D; i++)
            {
                LR[i] = Scanner.Scan<int, int>();
            }

            var ST = new (int S, int T)[K];
            for (var i = 0; i < K; i++)
            {
                ST[i] = Scanner.Scan<int, int>();
            }

            var answer = new int[K];
            for (var i = 0; i < K; i++)
            {
                var current = ST[i].S;
                var target = ST[i].T;
                var isInc = current < target;
                for (var j = 0; j < D; j++)
                {
                    if (current >= LR[j].L && current <= LR[j].R)
                        current = isInc ? LR[j].R : LR[j].L;
                    if (isInc && current >= target || !isInc && current <= target)
                    {
                        answer[i] = j + 1;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("\n", answer));
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
        }
    }
}
