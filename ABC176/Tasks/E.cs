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
            var (H, W, M) = Scanner.Scan<int, int, int>();
            var height = new int[H];
            var width = new int[W];
            var bombs = new HashSet<(int h, int w)>();
            for (var i = 0; i < M; i++)
            {
                var (h, w) = Scanner.Scan<int, int>();
                height[--h]++;
                width[--w]++;
                bombs.Add((h, w));
            }

            var hMax = 0;
            var wMax = 0;
            var hHash = new HashSet<int>();
            var wHash = new HashSet<int>();
            for (var i = 0; i < height.Length; i++)
            {
                if (hMax < height[i])
                {
                    hMax = height[i];
                    hHash.Clear();
                    hHash.Add(i);
                }
                else if (hMax == height[i])
                {
                    hHash.Add(i);
                }
            }

            for (var i = 0; i < width.Length; i++)
            {
                if (wMax < width[i])
                {
                    wMax = width[i];
                    wHash.Clear();
                    wHash.Add(i);
                }
                else if (wMax == width[i])
                {
                    wHash.Add(i);
                }
            }

            var answer = hMax + wMax;
            var ok = false;
            foreach (var h in hHash)
            {
                foreach (var w in wHash)
                {
                    if (!bombs.Contains((h, w))) ok = true;
                    if (ok) break;
                }
                if (ok) break;
            }

            if (!ok) answer--;

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
