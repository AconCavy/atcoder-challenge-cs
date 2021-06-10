using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

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
            var S = Scanner.Scan<string>();
            if (S == "a" || S == "zzzzzzzzzzzzzzzzzzzz")
            {
                Console.WriteLine("NO");
                return;
            }

            var rev = new string(S.Reverse().ToArray());
            if (rev != S)
            {
                Console.WriteLine(rev);
                return;
            }

            var s = 0;
            foreach (var c in S) s += c - 'a' + 1;

            if (s <= 26 && S.Length > 1)
            {
                var c = s - 1;
                Console.WriteLine((char)(c + 'a'));
                return;
            }

            var builder = new StringBuilder();
            while (s > 26)
            {
                builder.Append('z');
                s -= 26;
            }

            if (s == 1)
            {
                builder.Append('a');
            }
            else
            {
                if (builder.Length < 19)
                {
                    var c = (s - 2) % 26;
                    builder.Append((char)(c + 'a'));
                    builder.Append('a');
                }
                else
                {
                    var c = (s - 1) % 26;
                    builder.Append((char)(c + 'a'));
                }
            }

            var answer = builder.ToString();
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
