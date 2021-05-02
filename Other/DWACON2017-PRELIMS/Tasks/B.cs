using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class B
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
            var T = Scanner.Scan<string>();
            var t1 = new char[T.Length];
            var t2 = new char[T.Length];
            for (var i = 0; i < T.Length; i++)
            {
                if (T[i] == '?')
                {
                    t1[i] = i % 2 == 0 ? '2' : '5';
                    t2[i] = i % 2 == 1 ? '2' : '5';
                }
                else
                {
                    t1[i] = t2[i] = T[i];
                }
            }

            const string nico = "25";
            var c1 = MaxRepeatedCount(new string(t1), nico);
            var c2 = MaxRepeatedCount(new string(t2), nico);
            var answer = Math.Max(c1, c2) * 2;
            Console.WriteLine(answer);
        }

        public static int MaxRepeatedCount(string str, string tar)
        {
            var max = 0;
            var curr = 0;
            var prev = 0;
            var idx = 0;
            while (true)
            {
                idx = str.IndexOf(tar, idx);
                if (idx < 0)
                {
                    max = Math.Max(max, curr);
                    break;
                }

                if (idx == prev + tar.Length) curr++;
                else
                {
                    max = Math.Max(max, curr);
                    curr = 1;
                }

                prev = idx;
                idx += tar.Length;
            }

            return max;
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
