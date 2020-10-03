using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var (N, S) = Scanner.Scan<int, string>();
            var countA1 = new long[N];
            var countT1 = new long[N];
            var countC1 = new long[N];
            var countG1 = new long[N];
            var countA2 = new long[N];
            var countT2 = new long[N];
            var countC2 = new long[N];
            var countG2 = new long[N];
            for (var i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case 'A': countA1[i]++; countT2[i]++; break;
                    case 'T': countT1[i]++; countA2[i]++; break;
                    case 'C': countC1[i]++; countG2[i]++; break;
                    case 'G': countG1[i]++; countC2[i]++; break;
                    default: break;
                }
            }

            countA1 = CumulativeItems(countA1).ToArray();
            countT1 = CumulativeItems(countT1).ToArray();
            countC1 = CumulativeItems(countC1).ToArray();
            countG1 = CumulativeItems(countG1).ToArray();
            countA2 = CumulativeItems(countA2).ToArray();
            countT2 = CumulativeItems(countT2).ToArray();
            countC2 = CumulativeItems(countC2).ToArray();
            countG2 = CumulativeItems(countG2).ToArray();

            var answer = 0;
            for (var i = 2; i <= N; i++)
            {
                for (var j = i; j <= N; j++)
                {
                    var ok = true;
                    if (countA1[j] - countA1[j - i] != countA2[j] - countA2[j - i]) ok = false;
                    if (countT1[j] - countT1[j - i] != countT2[j] - countT2[j - i]) ok = false;
                    if (countC1[j] - countC1[j - i] != countC2[j] - countC2[j - i]) ok = false;
                    if (countG1[j] - countG1[j - i] != countG2[j] - countG2[j - i]) ok = false;
                    if (ok) answer++;
                }
            }

            Console.WriteLine(answer);
        }

        public static IEnumerable<long> CumulativeItems(IEnumerable<long> items)
        {
            var arr = items.ToArray();
            var ret = new long[arr.Length + 1];
            for (var i = 0; i < arr.Length; i++) ret[i + 1] = arr[i] + ret[i];
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
