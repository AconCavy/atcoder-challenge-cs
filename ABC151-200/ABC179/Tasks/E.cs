using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class E
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
            var (N, X, M) = Scanner.Scan<long, long, long>();
            var a = X;
            var dict = new Dictionary<long, int>();
            dict[a] = 1;
            var agg = new List<long>() { 0, a };
            var loopStart = 0;
            var loopEnd = -1;
            for (var n = 2; n <= N; n++)
            {
                a = a * a % M;
                agg.Add(agg[agg.Count - 1] + a);
                if (dict.ContainsKey(a))
                {
                    loopStart = dict[a];
                    loopEnd = n;
                    break;
                }
                else dict[a] = n;
            }
            var answer = agg[agg.Count - 1];
            var remains = N - loopEnd;
            if (loopEnd > 0 && remains > 0)
            {
                answer += (agg[loopEnd] - agg[loopStart]) * (remains / (loopEnd - loopStart));
                var rem = (int)(remains % (loopEnd - loopStart));
                answer += agg[loopStart + rem] - agg[loopStart];
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
