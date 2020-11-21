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
            var (H, W) = Scanner.Scan<int, int>();
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().Select((x, i) => (x, i)).ToArray();
            Array.Sort(A, (x, y) => x.x.CompareTo(y.x));
            var G = new int[H][].Select(_ => new int[W]).ToArray();
            var (cx, cy) = (0, 0);
            foreach (var (x, i) in A)
            {
                var rem = x;
                var color = i + 1;
                while (rem-- > 0)
                {
                    G[cx][cy] = color;
                    if (cy % 2 == 0 && cx == (H - 1) || cy % 2 == 1 && cx == 0) cy++;
                    else
                    {
                        if (cy % 2 == 0) cx++;
                        else cx--;
                    }
                }
            }
            Console.WriteLine(string.Join("\n", G.Select(x => string.Join(" ", x))));
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
