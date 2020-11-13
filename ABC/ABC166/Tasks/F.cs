using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tasks
{
    public class F
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
            var (N, A, B, C) = Scanner.Scan<int, long, long, long>();
            var S = new int[N].Select(_ => Scanner.Scan<string>().Sum(x => x - 'A' + 1)).ToArray();
            var answer = new char[N];
            var index = 0;
            var ok = true;

            (bool, long, long) Check0(long x, long y)
            {
                if (x == 0 || y == 0)
                {
                    if (y != 0) return (true, x + 1, y - 1);
                    if (x != 0) return (true, x - 1, y + 1);
                    return (false, -1, -1);
                }
                return x <= y ? (true, x + 1, y - 1) : (true, x - 1, y + 1);
            }

            bool Check(int comb)
            {
                var ret = false;
                long a, b, c;
                if (comb == 3)
                {
                    (ret, a, b) = Check0(A, B);
                    answer[index++] = a - A == 1 ? 'A' : 'B';
                    A = a; B = b;
                }
                else if (comb == 4)
                {
                    (ret, c, a) = Check0(C, A);
                    answer[index++] = c - C == 1 ? 'C' : 'A';
                    A = a; C = c;
                }
                else if (comb == 5)
                {
                    (ret, b, c) = Check0(B, C);
                    answer[index++] = b - B == 1 ? 'B' : 'C';
                    B = b; C = c;
                }
                return ret;
            }

            if (A + B + C == 2)
            {
                for (var i = 0; i < N && ok; i++)
                {
                    var tmp = true;
                    if (A + B + C == 2)
                    {
                        if (i + 1 < N && S[i] != S[i + 1])
                        {
                            if (S[i] == 3 && A == 1 && B == 1
                            || S[i] == 4 && C == 1 && A == 1
                            || S[i] == 5 && B == 1 && C == 1)
                            {
                                tmp = false;
                                var remain = S[i] + S[i + 1] - 6;
                                // AB, AC = 3 + 4 = 7 -> 1
                                // AB, BC = 3 + 5 = 8 -> 2
                                // AC, AB = 4 + 3 = 7 -> 1
                                // AC, BC = 4 + 5 = 9 -> 3
                                // BC, AB = 5 + 3 = 8 -> 2
                                // BC, AC = 5 + 4 = 9 -> 3
                                if (S[i] == 3)
                                {
                                    if (remain == 1) { A++; B--; answer[index++] = 'A'; }
                                    else { B++; A--; answer[index++] = 'B'; }
                                }
                                if (S[i] == 4)
                                {
                                    if (remain == 1) { A++; C--; answer[index++] = 'A'; }
                                    else { C++; A--; answer[index++] = 'C'; }
                                }
                                if (S[i] == 5)
                                {
                                    if (remain == 2) { B++; C--; answer[index++] = 'B'; }
                                    else { C++; B--; answer[index++] = 'C'; }
                                }
                            }
                        }
                    }
                    if (tmp) ok = Check(S[i]);
                    // Console.WriteLine($"{A} {B} {C}");
                }
            }
            else { for (var i = 0; i < N && ok; i++) ok = Check(S[i]); }

            Console.WriteLine(ok ? "Yes" : "No");
            if (ok) Console.WriteLine(string.Join("\n", answer));
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
