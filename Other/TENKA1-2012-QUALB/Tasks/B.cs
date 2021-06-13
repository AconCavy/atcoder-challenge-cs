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
            var S = Scanner.Scan<string>();
            var (l, r) = (0, 0);
            while (l < S.Length && S[l] == '_') l++;
            while (r < S.Length && S[S.Length - 1 - r] == '_') r++;
            if (l == r && l == S.Length)
            {
                Console.WriteLine(S);
                return;
            }

            bool Check(IEnumerable<string> words)
            {
                foreach (var word in words)
                {
                    if (string.IsNullOrEmpty(word) || char.IsDigit(word[0]) || char.IsUpper(word[0]))
                    {
                        return false;
                    }
                }
                return true;
            }

            var lc = S[l..^r].Split('_');

            if (!Check(lc))
            {
                Console.WriteLine(S);
                return;
            }

            string ToLowerCamel(IEnumerable<string> words)
            {
                var tmp = new List<string> { words.First() };
                foreach (var word in words.Skip(1))
                {
                    var s = word.ToLower().ToCharArray();
                    s[0] = char.ToUpper(s[0]);
                    tmp.Add(new string(s));
                }

                return string.Join("", tmp);
            }

            string ToSnake(string word)
            {
                var tmp = new List<string>();
                var (l, r) = (0, 1);
                while (l < word.Length)
                {
                    while (r < word.Length && !char.IsUpper(word[r])) r++;
                    var s = word[l..r].ToLower().ToCharArray();
                    s[0] = char.ToLower(s[0]);
                    tmp.Add(new string(s));
                    l = r;
                    r++;
                }

                return string.Join("_", tmp);
            }

            var str = "";
            if (lc.Length == 1) str = ToSnake(lc[0]);
            else str = ToLowerCamel(lc);

            var answer = new string('_', l) + str + new string('_', r);
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
