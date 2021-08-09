using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class F
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
            var sa = StringAlgorithm.SuffixArray(S);
            var lcp = StringAlgorithm.LongestCommonPrefixArray(S, sa);

            var answer = new long[N];
            for (var i = 0; i < N; i++)
            {
                answer[i] = N - i;
            }

            for (var k = 0; k < 2; k++)
            {
                var stack = new Stack<(long H, long W)>();
                var s = 0L;
                for (var i = 0; i < N - 1; i++)
                {
                    var w = 1L;
                    while (stack.TryPeek(out var top) && top.H > lcp[i])
                    {
                        w += top.W;
                        s -= top.H * top.W;
                        stack.Pop();
                    }

                    s += lcp[i] * w;
                    stack.Push((lcp[i], w));
                    answer[sa[i + 1]] += s;
                }

                Array.Reverse(sa);
                Array.Reverse(lcp);
            }

            Console.WriteLine(string.Join("\n", answer));
        }

        public static class StringAlgorithm
        {
            public static int[] SuffixArray(string str) => SuffixArray(str.Select(x => (int)x), char.MaxValue);
            public static int[] SuffixArray<T>(IEnumerable<T> source) where T : IEquatable<T>
            {
                if (source is null) throw new ArgumentNullException(nameof(source));
                var s = source.ToArray();
                var n = s.Length;
                var idx = Enumerable.Range(0, n).ToArray();
                Array.Sort(idx, (x, y) => Comparer<T>.Default.Compare(s[x], s[y]));
                var s2 = new int[n];
                var now = 0;
                for (var i = 0; i < n; i++)
                {
                    if (i > 0 && !s[idx[i - 1]].Equals(s[idx[i]])) now++;
                    s2[idx[i]] = now;
                }
                return SuffixArrayByInducedSorting(s2, now);
            }
            public static int[] SuffixArray(IEnumerable<int> source, int upper)
            {
                if (source is null) throw new ArgumentNullException(nameof(source));
                if (upper < 0) throw new ArgumentException(nameof(upper));
                var s = source.ToArray();
                if (s.Any(x => x < 0 || upper < x)) throw new ArgumentException(nameof(source));
                return SuffixArrayByInducedSorting(s, upper);
            }
            public static int[] LongestCommonPrefixArray(string str, int[] suffixArray) =>
                LongestCommonPrefixArray(str.Select(x => (int)x), suffixArray);
            public static int[] LongestCommonPrefixArray<T>(IEnumerable<T> source, int[] suffixArray)
                where T : IEquatable<T>
            {
                if (source is null) throw new ArgumentNullException(nameof(source));
                var s = source.ToArray();
                var n = s.Length;
                if (n < 1) throw new ArgumentException(nameof(source));
                var rnk = new int[n];
                for (var i = 0; i < rnk.Length; i++) rnk[suffixArray[i]] = i;
                var lcp = new int[n - 1];
                var h = 0;
                for (var i = 0; i < n; i++)
                {
                    if (h > 0) h--;
                    if (rnk[i] == 0) continue;
                    var j = suffixArray[rnk[i] - 1];
                    while (j + h < n && i + h < n)
                    {
                        if (!s[j + h].Equals(s[i + h])) break;
                        h++;
                    }
                    lcp[rnk[i] - 1] = h;
                }
                return lcp;
            }
            public static int[] ZAlgorithm(string str) => ZAlgorithm(str.Select(x => (int)x));
            public static int[] ZAlgorithm<T>(IEnumerable<T> source) where T : IEquatable<T>
            {
                if (source is null) throw new ArgumentNullException(nameof(source));
                var s = source.ToArray();
                var n = s.Length;
                if (n == 0) return Array.Empty<int>();
                var z = new int[n];
                for (int i = 1, j = 0; i < n; i++)
                {
                    z[i] = j + z[j] <= i ? 0 : Math.Min(j + z[j] - i, z[i - j]);
                    while (i + z[i] < n && s[z[i]].Equals(s[i + z[i]])) z[i]++;
                    if (j + z[j] < i + z[i]) j = i;
                }
                z[0] = n;
                return z;
            }
            private static int[] SuffixArrayByInducedSorting(int[] source, int upper, int naive = 10, int doubling = 40)
            {
                var n = source.Length;
                switch (n)
                {
                    case 0: return Array.Empty<int>();
                    case 1: return new[] { 0 };
                    case 2: return source[0] < source[1] ? new[] { 0, 1 } : new[] { 1, 0 };
                }
                if (n < naive) return SuffixArrayByNaive(source);
                if (n < doubling) return SuffixArrayByDoubling(source);
                var sa = new int[n];
                var ls = new bool[n];
                for (var i = n - 2; i >= 0; i--)
                {
                    ls[i] = source[i] == source[i + 1] ? ls[i + 1] : source[i] < source[i + 1];
                }
                var sumL = new int[upper + 1];
                var sumS = new int[upper + 1];
                for (var i = 0; i < n; i++)
                {
                    if (!ls[i]) sumS[source[i]]++;
                    else sumL[source[i] + 1]++;
                }
                for (var i = 0; i <= upper; i++)
                {
                    sumS[i] += sumL[i];
                    if (i < upper) sumL[i + 1] += sumS[i];
                }
                void Induce(IEnumerable<int> ilms)
                {
                    Array.Fill(sa, -1);
                    var buffer = new int[upper + 1];
                    sumS.CopyTo(buffer, 0);
                    foreach (var d in ilms)
                    {
                        if (d == n) continue;
                        sa[buffer[source[d]]++] = d;
                    }
                    sumL.CopyTo(buffer, 0);
                    sa[buffer[source[n - 1]]++] = n - 1;
                    for (var i = 0; i < n; i++)
                    {
                        var v = sa[i];
                        if (v >= 1 && !ls[v - 1]) sa[buffer[source[v - 1]]++] = v - 1;
                    }
                    sumL.CopyTo(buffer, 0);
                    for (var i = n - 1; i >= 0; i--)
                    {
                        var v = sa[i];
                        if (v >= 1 && ls[v - 1]) sa[--buffer[source[v - 1] + 1]] = v - 1;
                    }
                }
                var lmsMap = new int[n + 1];
                Array.Fill(lmsMap, -1);
                var m = 0;
                for (var i = 1; i < n; i++)
                {
                    if (!ls[i - 1] && ls[i]) lmsMap[i] = m++;
                }
                var lms = new List<int>();
                for (var i = 1; i < n; i++)
                {
                    if (!ls[i - 1] && ls[i]) lms.Add(i);
                }
                Induce(lms);
                if (m <= 0) return sa;
                var sortedLms = sa.Where(x => lmsMap[x] != -1).ToArray();
                var recS = new int[m];
                var recUpper = 0;
                recS[lmsMap[sortedLms[0]]] = 0;
                for (var i = 1; i < m; i++)
                {
                    var l = sortedLms[i - 1];
                    var r = sortedLms[i];
                    var el = lmsMap[l] + 1 < m ? lms[lmsMap[l] + 1] : n;
                    var er = lmsMap[r] + 1 < m ? lms[lmsMap[r] + 1] : n;
                    var isSame = true;
                    if (el - l != er - r)
                    {
                        isSame = false;
                    }
                    else
                    {
                        while (l < el && source[l] == source[r])
                        {
                            l++;
                            r++;
                        }
                        if (l == n || source[l] != source[r]) isSame = false;
                    }
                    if (!isSame) recUpper++;
                    recS[lmsMap[sortedLms[i]]] = recUpper;
                }
                var recSa = SuffixArrayByInducedSorting(recS, recUpper, naive, doubling).ToArray();
                for (var i = 0; i < m; i++)
                {
                    sortedLms[i] = lms[recSa[i]];
                }
                Induce(sortedLms);
                return sa;
            }
            private static int[] SuffixArrayByNaive(int[] source)
            {
                var n = source.Length;
                var sa = Enumerable.Range(0, n).ToArray();
                int Compare(int x, int y)
                {
                    if (x == y) return 0;
                    while (x < n && y < n)
                    {
                        if (source[x] != source[y]) return source[x].CompareTo(source[y]);
                        x++;
                        y++;
                    }
                    return y.CompareTo(x);
                }
                Array.Sort(sa, Compare);
                return sa;
            }
            private static int[] SuffixArrayByDoubling(int[] source)
            {
                var n = source.Length;
                var sa = Enumerable.Range(0, n).ToArray();
                var tmp = new int[n];
                for (var k = 1; k < n; k *= 2)
                {
                    int Compare(int x, int y)
                    {
                        if (source[x] != source[y]) return source[x].CompareTo(source[y]);
                        var rx = x + k < n ? source[x + k] : -1;
                        var ry = y + k < n ? source[y + k] : -1;
                        return rx.CompareTo(ry);
                    }
                    Array.Sort(sa, Compare);
                    tmp[sa[0]] = 0;
                    for (var i = 1; i < n; i++)
                    {
                        tmp[sa[i]] = tmp[sa[i - 1]] + (Compare(sa[i - 1], sa[i]) < 0 ? 1 : 0);
                    }
                    (tmp, source) = (source, tmp);
                }
                return sa;
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
