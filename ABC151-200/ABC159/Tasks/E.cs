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
            var (H, W, K) = Scanner.Scan<int, int, int>();
            var S = new bool[H][].Select(x => Scanner.Scan<string>().Select(x => x == '1').ToArray()).ToArray();
            var answer = (int)1e9;
            for (var b = 0; b < 1 << (H - 1); b++)
            {
                var (cutH, cutW) = (0, 0);
                var map = new int[H];
                for (var i = 0; i < H - 1; i++)
                {
                    map[i] = cutH;
                    if ((b >> i & 1) == 1) cutH++;
                }
                map[H - 1] = cutH;
                var count = new int[cutH + 1];
                var ok = true;
                for (var j = 0; j < W && ok; j++)
                {
                    var tmp = count.ToArray();
                    for (var i = 0; i < H; i++)
                        if (S[i][j]) tmp[map[i]]++;
                    if (tmp.Any(x => x > K))
                    {
                        if (j == 0) ok = false;
                        else
                        {
                            cutW++;
                            for (var i = 0; i <= cutH; i++)
                                count[i] = tmp[i] - count[i];
                        }
                    }
                    else count = tmp.ToArray();
                }
                if (ok) answer = Math.Min(answer, cutH + cutW);
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
