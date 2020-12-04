using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace Tasks
{
    public class C
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
            var constraints = new List<(int, int)>();
            for (var i = 0; i < 8; i++)
            {
                var S = Scanner.Scan<string>();
                for (var j = 0; j < S.Length; j++)
                {
                    if (S[j] == 'Q') constraints.Add((i, j));
                }
            }

            var (result, answer) = NQueensProblem.Identify(8, constraints);
            if (result)
                Console.WriteLine(string.Join("\n", answer.Select(x => new string(x.Select(y => y ? 'Q' : '.').ToArray()))));
            else Console.WriteLine("No Answer");
        }

        public static class NQueensProblem
        {
            public static (bool isIdentified, bool[][] answer) Identify(int size,
            IEnumerable<(int row, int column)> constraints = null)
            {
                var answer = new bool[size][].Select(_ => new bool[size]).ToArray();
                var isIdentified = false;
                var points = constraints?.ToArray() ?? Array.Empty<(int, int)>();
                foreach (var (r, c) in points) answer[r][c] = true;
                if (points.Any(x => !Check(x.row, x.column))) return (false, answer);

                bool Check(int r, int c)
                {
                    for (var i = 0; i < size; i++)
                    {
                        if (i != c && answer[r][i]) return false;
                        if (i != r && answer[i][c]) return false;
                    }

                    var d4 = new[] { (1, 1), (1, -1), (-1, 1), (-1, -1) };
                    for (var i = 1; i < size; i++)
                    {
                        foreach (var (dr, dc) in d4)
                        {
                            var (nr, nc) = (r + dr * i, c + dc * i);
                            if (nr < 0 || size <= nr || nc < 0 || size <= nc) continue;
                            if (answer[nr][nc]) return false;
                        }
                    }

                    return true;
                }

                void Inner(int placed)
                {
                    if (isIdentified) return;
                    if (placed == size)
                    {
                        isIdentified = true;
                        return;
                    }

                    for (var r = 0; r < size; r++)
                    {
                        for (var c = 0; c < size; c++)
                        {
                            if (answer[r][c] || !Check(r, c)) continue;
                            answer[r][c] = true;
                            Inner(placed + 1);
                            if (isIdentified) return;
                            answer[r][c] = false;
                        }
                    }
                }

                Inner(points.Length);
                return (isIdentified, answer);
            }
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
