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
            var N = Scanner.Scan<long>();
            var depth = 0;
            while ((1L << depth) <= N) depth++;
            var tmp = 1L;
            var t = 0;
            if (depth % 2 == 0)
            {
                while (tmp <= N)
                {
                    if (t % 2 == 0) tmp = tmp * 2;
                    else tmp = tmp * 2 + 1;
                    t++;
                }
            }
            else
            {
                while (tmp <= N)
                {
                    if (t % 2 == 1) tmp = tmp * 2;
                    else tmp = tmp * 2 + 1;
                    t++;
                }
            }

            Console.WriteLine(t % 2 == 0 ? "Takahashi" : "Aoki");
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
