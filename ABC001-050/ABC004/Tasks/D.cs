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
            var (R, G, B) = Scanner.Scan<int, int, int>();
            var answer = (long)1e18;
            long CalcCost(int count, int left, int center)
            {
                var ret = 0L;
                for (var i = left; i < left + count; i++)
                {
                    ret += Math.Abs(i - center);
                }
                return ret;
            }

            for (var i = -500; i <= 500; i++)
            {
                var tmp = CalcCost(G, i, 0);
                tmp += i < -100 + R / 2 ? CalcCost(R, i - R, -100) : CalcCost(R, -100 - R / 2, -100);
                tmp += i + G > 100 - B / 2 ? CalcCost(B, i + G, 100) : CalcCost(B, 100 - B / 2, 100);
                answer = Math.Min(answer, tmp);
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
