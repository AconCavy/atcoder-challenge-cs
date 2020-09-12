using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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
            var S = Scanner.Scan<string>();
            var Q = Scanner.Scan<int>();
            var rev = false;
            var lsb = new StringBuilder();
            var rsb = new StringBuilder(S);
            for (var i = 0; i < Q; i++)
            {
                var query = Scanner.ScanEnumerable<string>().ToArray();
                if (int.Parse(query[0]) == 1) rev = !rev;
                else
                {
                    var (f, c) = (int.Parse(query[1]), query[2][0]);
                    if (f == 1)
                    {
                        if (rev) rsb.Append(c);
                        else lsb.Append(c);
                    }
                    else
                    {
                        if (rev) lsb.Append(c);
                        else rsb.Append(c);
                    }
                }
            }
            var l = lsb.ToString();
            var r = rsb.ToString();
            var answer = rev ? Reverse(r) + l : Reverse(l) + r;
            Console.WriteLine(answer);
        }

        static string Reverse(string str)
        {
            var chars = str.ToCharArray();
            for (int i = 0, j = str.Length - 1; i < j; i++, j--)
            {
                (chars[i], chars[j]) = (chars[j], chars[i]);
            }
            return new string(chars);
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
