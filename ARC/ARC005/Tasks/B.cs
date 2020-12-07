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
            var (x, y, W) = Scanner.Scan<int, int, string>();
            var G = new string[9];
            for (var i = 0; i < 9; i++)
            {
                var S = Scanner.Scan<string>();
                G[i] = S;
            }

            var (dx, dy) = (0, 0);
            foreach (var c in W)
            {
                if (c == 'R') dx++;
                if (c == 'L') dx--;
                if (c == 'U') dy--;
                if (c == 'D') dy++;
            }

            x--; y--;

            var answer = new StringBuilder();
            for (var i = 0; i < 4; i++)
            {
                answer.Append(G[y][x]);
                if (x + dx < 0 || 9 <= x + dx) dx *= -1;
                if (y + dy < 0 || 9 <= y + dy) dy *= -1;
                x += dx;
                y += dy;
            }

            Console.WriteLine(answer.ToString());
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
