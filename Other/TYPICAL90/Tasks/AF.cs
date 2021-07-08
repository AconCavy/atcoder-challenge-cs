using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Sandbox.Extensions;

namespace Tasks
{
    public class AF
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
            var N = Scanner.Scan<int>();
            var A = new long[N][];
            for (var i = 0; i < N; i++)
            {
                A[i] = Scanner.ScanEnumerable<long>().ToArray();
            }

            var B = new bool[N, N];
            for (var i = 0; i < N; i++)
            {
                for (var j = 0; j < N; j++)
                {
                    B[i, j] = true;
                }
            }

            var M = Scanner.Scan<int>();
            for (var i = 0; i < M; i++)
            {
                var (x, y) = Scanner.Scan<int, int>();
                x--; y--;
                B[x, y] = B[y, x] = false;
            }

            const long inf = (long)1e18;
            var answer = inf;

            foreach (var p in Enumerable.Range(0, N).Permute())
            {
                var order = p.ToArray();
                var ok = true;
                for (var i = 1; i < N; i++)
                {
                    ok &= B[order[i], order[i - 1]];
                }

                if (!ok) continue;
                var sum = 0L;
                for (var i = 0; i < N; i++)
                {
                    sum += A[order[i]][i];
                }

                answer = Math.Min(answer, sum);
            }

            if (answer == inf) answer = -1;
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
            public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() => (Next<T1>(), Next<T2>(), Next<T3>(), Next<T4>(), Next<T5>(), Next<T6>());
            public static IEnumerable<T> ScanEnumerable<T>() => Console.ReadLine().Trim().Split(" ").Select(x => (T)Convert.ChangeType(x, typeof(T)));
        }
    }
}

namespace Sandbox.Extensions
{
    public static partial class EnumerableExtension
    {
        public static IEnumerable<IEnumerable<T>> Permute<T>(this IEnumerable<T> source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            IEnumerable<IEnumerable<T>> Inner()
            {
                var items = source.ToArray();
                var ret = new T[items.Length];
                foreach (var indices in PermuteIndices(items.Length))
                {
                    var idx = 0;
                    foreach (var index in indices) ret[idx++] = items[index];
                    yield return ret;
                }
            }
            return Inner();
        }
        private static IEnumerable<IEnumerable<int>> PermuteIndices(int n)
        {
            var indices = Enumerable.Range(0, n).ToArray();
            yield return indices;
            while (true)
            {
                var (i, j) = (indices.Length - 2, indices.Length - 1);
                while (i >= 0)
                {
                    if (indices[i] < indices[i + 1]) break;
                    i--;
                }
                if (i == -1) yield break;
                while (true)
                {
                    if (indices[j] > indices[i]) break;
                    j--;
                }
                (indices[i], indices[j]) = (indices[j], indices[i]);
                Array.Reverse(indices, i + 1, indices.Length - 1 - i);
                yield return indices;
            }
        }
    }
}