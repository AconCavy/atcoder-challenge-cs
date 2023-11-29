using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks;

public class E
{
    public static void Main()
    {
        using var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
        Console.SetOut(sw);
        Solve();
        Console.Out.Flush();
    }

    public static void Solve()
    {
        var (N, Q) = Scanner.Scan<int, int>();
        var A = Scanner.ScanEnumerable<int>().ToArray();
        var count = new int[N + 1];
        var mex = new Mex(N);
        foreach (var a in A.Where(x => x < N))
        {
            count[a]++;
            mex.Add(a);
        }

        for (var q = 0; q < Q; q++)
        {
            var (i, x) = Scanner.Scan<int, int>();
            i--;

            if (A[i] < N)
            {
                count[A[i]]--;
                if (count[A[i]] == 0) mex.Remove(A[i]);
            }

            A[i] = x;

            if (x < N)
            {
                count[x]++;
                mex.Add(x);
            }

            var answer = Math.Min(mex.Get(), N);
            Console.WriteLine(answer);
        }
    }

    public class Mex
    {
        public int RightBound { get; init; }
        private readonly SortedSet<int> _heap;
        public Mex(int rightBound)
        {
            RightBound = rightBound;
            _heap = new SortedSet<int>(Enumerable.Range(0, rightBound + 1));
        }

        public void Add(int x)
        {
            _heap.Remove(x);
        }

        public int Get()
        {
            return _heap.Count > 0 ? _heap.Min : RightBound;
        }

        public void Remove(int x)
        {
            _heap.Add(Math.Min(x, RightBound));
        }
    }

    public static class Scanner
    {
        public static T Scan<T>() where T : IConvertible => Convert<T>(ScanStringArray()[0]);
        public static (T1, T2) Scan<T1, T2>() where T1 : IConvertible where T2 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]));
        }
        public static (T1, T2, T3) Scan<T1, T2, T3>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]));
        }
        public static (T1, T2, T3, T4) Scan<T1, T2, T3, T4>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]));
        }
        public static (T1, T2, T3, T4, T5) Scan<T1, T2, T3, T4, T5>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]));
        }
        public static (T1, T2, T3, T4, T5, T6) Scan<T1, T2, T3, T4, T5, T6>() where T1 : IConvertible where T2 : IConvertible where T3 : IConvertible where T4 : IConvertible where T5 : IConvertible where T6 : IConvertible
        {
            var input = ScanStringArray();
            return (Convert<T1>(input[0]), Convert<T2>(input[1]), Convert<T3>(input[2]), Convert<T4>(input[3]), Convert<T5>(input[4]), Convert<T6>(input[5]));
        }
        public static IEnumerable<T> ScanEnumerable<T>() where T : IConvertible => ScanStringArray().Select(Convert<T>);
        private static string[] ScanStringArray()
        {
            var line = Console.ReadLine()?.Trim() ?? string.Empty;
            return string.IsNullOrEmpty(line) ? Array.Empty<string>() : line.Split(' ');
        }
        private static T Convert<T>(string value) where T : IConvertible => (T)System.Convert.ChangeType(value, typeof(T));
    }
}
