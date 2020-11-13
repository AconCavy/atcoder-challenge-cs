using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var N = Scanner.Scan<int>();
            var S = Scanner.Scan<string>();
            var ok = true;
            if (S.Length % 2 == 0) ok = false;
            if (S.Length == 1)
            {
                ok = S[0] == 'b';
            }
            else
            {
                for (var i = 0; i < S.Length - 1; i++)
                {
                    if (S[i] != 'a' && S[i] != 'b' && S[i] != 'c') ok = false;
                    if (S[i] == 'a' && S[i + 1] != 'b') ok = false;
                    if (S[i] == 'b' && S[i + 1] != 'c') ok = false;
                    if (S[i] == 'c' && S[i + 1] != 'a') ok = false;
                }

                switch (N % 3)
                {
                    case 0: ok = S[0] == 'a' ? ok : false; break;
                    case 1: ok = S[0] == 'b' ? ok : false; break;
                    case 2: ok = S[0] == 'c' ? ok : false; break;
                }
            }

            Console.WriteLine(ok ? N / 2 : -1);
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
        }
    }
}
