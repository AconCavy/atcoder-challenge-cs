using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.VisualBasic;

namespace Tasks
{
    public class E
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
            var S = Scanner.Scan<string>();
            var list = new LinkedList<int>();

            void CheckFirst(int idx)
            {
                if (list.Count <= idx)
                {
                    Console.WriteLine("ERROR");
                    return;
                }

                var stack = new Stack<int>();
                while (idx > 0)
                {
                    stack.Push(list.First.Value);
                    list.RemoveFirst();
                    idx--;
                }

                Console.WriteLine(list.First.Value);
                list.RemoveFirst();
                while (stack.Count > 0)
                {
                    list.AddFirst(stack.Pop());
                }
            }

            void CheckLast(int idx)
            {
                if (list.Count <= idx)
                {
                    Console.WriteLine("ERROR");
                    return;
                }

                var stack = new Stack<int>();
                while (idx > 0)
                {
                    stack.Push(list.Last.Value);
                    list.RemoveLast();
                    idx--;
                }

                Console.WriteLine(list.Last.Value);
                list.RemoveLast();
                while (stack.Count > 0)
                {
                    list.AddLast(stack.Pop());
                }
            }

            for (var i = 0; i < N; i++)
            {
                switch (S[i])
                {
                    case 'L': list.AddFirst(i + 1); break;
                    case 'R': list.AddLast(i + 1); break;
                    case 'A': CheckFirst(0); break;
                    case 'B': CheckFirst(1); break;
                    case 'C': CheckFirst(2); break;
                    case 'D': CheckLast(0); break;
                    case 'E': CheckLast(1); break;
                    case 'F': CheckLast(2); break;
                    default: break;
                }
            }
        }

        public static class Scanner
        {
            private static Queue<string> queue = new Queue<string>();
            public static T Next<T>()
            {
                if (queue.Count == 0) foreach (var item in Console.ReadLine().Trim().Split(" ")) queue.Enqueue(item);
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
