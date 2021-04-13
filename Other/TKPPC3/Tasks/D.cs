using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class D
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
            var (H, W, Q) = Scanner.Scan<int, int, int>();
            var A = Scanner.ScanEnumerable<long>().ToArray();
            var B = Scanner.ScanEnumerable<long>().ToArray();

            var evenH = new long[H + 1];
            var oddH = new long[H + 1];
            var evenW = new long[W + 1];
            var oddW = new long[W + 1];
            for (var i = 0; i < H; i++)
            {
                evenH[i + 1] = evenH[i];
                oddH[i + 1] = oddH[i];
                (i % 2 == 0 ? evenH : oddH)[i + 1] += A[i];
            }

            for (var i = 0; i < W; i++)
            {
                evenW[i + 1] = evenW[i];
                oddW[i + 1] = oddW[i];
                (i % 2 == 0 ? evenW : oddW)[i + 1] += B[i];
            }

            while (Q-- > 0)
            {
                var (px, py, qx, qy) = Scanner.Scan<int, int, int, int>();
                px--; py--;
                var b = (evenH[qx] - evenH[px]) * (evenW[qy] - evenW[py]);
                b += (oddH[qx] - oddH[px]) * (oddW[qy] - oddW[py]);
                var w = (oddH[qx] - oddH[px]) * (evenW[qy] - evenW[py]);
                w += (evenH[qx] - evenH[px]) * (oddW[qy] - oddW[py]);
                Console.WriteLine(b - w);
            }
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
