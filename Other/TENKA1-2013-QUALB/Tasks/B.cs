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
            var (Q, L) = Scanner.Scan<int, long>();

            var stack = new Stack<(int, int)>();
            var size = 0L;

            bool Push(int n, int m)
            {
                if (size + n > L) return false;
                stack.Push((m, n));
                size += n;
                return true;
            }

            bool Pop(int n)
            {
                if (size < n) return false;
                size -= n;
                while (n > 0)
                {
                    var (x, m) = stack.Pop();
                    if (m > n) stack.Push((x, m - n));
                    n -= m;
                }
                return true;
            }

            bool Top()
            {
                if (size == 0) return false;
                var (x, _) = stack.Peek();
                Console.WriteLine(x);
                return true;
            }

            void Size()
            {
                Console.WriteLine(size);
            }

            while (Q-- > 0)
            {
                var query = Console.ReadLine().Trim().Split(" ");
                if (query[0] == "Push")
                {
                    var (n, m) = (int.Parse(query[1]), int.Parse(query[2]));
                    var ok = Push(n, m);
                    if (!ok)
                    {
                        Console.WriteLine("FULL");
                        return;
                    }
                }
                if (query[0] == "Pop")
                {
                    var n = int.Parse(query[1]);
                    var ok = Pop(n);
                    if (!ok)
                    {
                        Console.WriteLine("EMPTY");
                        return;
                    }
                }
                if (query[0] == "Top")
                {
                    var ok = Top();
                    if (!ok)
                    {
                        Console.WriteLine("EMPTY");
                        return;
                    }
                }
                if (query[0] == "Size") Size();
            }

            Console.WriteLine("SAFE");
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
