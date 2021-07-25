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
            var N = Scanner.Scan<int>();
            var A = Scanner.ScanEnumerable<int>().ToArray();
            var B = Scanner.ScanEnumerable<int>().ToArray();
            var bdict = new Dictionary<int, int>();
            foreach (var b in B)
            {
                if (!bdict.ContainsKey(b)) bdict[b] = 0;
                bdict[b]++;
            }

            var hashset = new HashSet<int>();
            foreach (var a in A)
            {
                foreach (var b in B)
                {
                    hashset.Add(a ^ b);
                }
            }

            var answer = new List<int>();
            foreach (var x in hashset)
            {
                var tmp = new Dictionary<int, int>();
                var ok = true;
                foreach (var a in A)
                {
                    var b = x ^ a;
                    if (!bdict.ContainsKey(b))
                    {
                        ok = false;
                        break;
                    }

                    if (!tmp.ContainsKey(b)) tmp[b] = 0;
                    tmp[b]++;
                    if (tmp[b] > bdict[b])
                    {
                        ok = false;
                        break;
                    }
                }

                foreach (var (k, v) in bdict)
                {
                    if (tmp.ContainsKey(k))
                    {
                        ok &= v == tmp[k];
                    }
                    else
                    {
                        ok = false;
                    }

                    if (!ok) break;
                }

                if (ok) answer.Add(x);
            }

            Console.WriteLine(answer.Count);
            if (answer.Count == 0) return;
            answer.Sort();
            foreach (var a in answer)
            {
                Console.WriteLine(a);
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
