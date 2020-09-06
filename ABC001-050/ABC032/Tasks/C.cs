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
            var (N, K) = Scanner.Scan<int, long>();
            var S = new long[N];
            for (var i = 0; i < N; i++)
            {
                S[i] = Scanner.Scan<long>();
            }

            if (S.Contains(0))
            {
                Console.WriteLine(N);
                return;
            }

            var answer = 0L;
            var tmp = 1L;
            var l = 0;
            var r = 0;
            while (l < N)
            {
                if (l == r) tmp = 1;
                while (r < N && tmp * S[r] <= K)
                {
                    tmp *= S[r++];
                }
                // Console.WriteLine($"{tmp}: {l}, {r}");
                answer = Math.Max(answer, r - l);

                tmp /= S[l++];
                if (r < l) r = l;
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
        }
    }
}
