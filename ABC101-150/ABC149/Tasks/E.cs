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
            var (N, M) = Scanner.Scan<int, long>();
            var A = Scanner.ScanEnumerable<long>().OrderByDescending(x => x).ToArray();
            var l = 0;
            var r = (int)2e5 + 1;
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                var tmp = 0L;
                foreach (var a in A) tmp += CountOfGreater(A, m - a);
                if (M <= tmp) l = m;
                else r = m;
            }

            var answer = 0L;
            var cum = CumulativeItems(A).ToArray();
            var count = 0L;
            var min = (long)1e18;
            foreach (var a in A)
            {
                var greater = CountOfGreater(A, l - a);
                count += greater;
                if (greater != 0) min = Math.Min(min, a + A[greater - 1]);
                answer += greater * a;
                answer += cum[greater];
            }

            answer -= Math.Max(0, count - M) * min;
            Console.WriteLine(answer);
        }

        public static int CountOfGreater(long[] descendingItems, long value)
        {
            var l = -1;
            var r = descendingItems.Length;
            while (r - l > 1)
            {
                var m = l + (r - l) / 2;
                if (value <= descendingItems[m]) l = m;
                else r = m;
            }
            return l + 1;
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
