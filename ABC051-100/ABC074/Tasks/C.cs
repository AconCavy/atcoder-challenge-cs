using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var (A, B, C, D, E, F) = Scanner.Scan<int, int, int, int, int, int>();

            var answerVolume = 100 * A;
            var answerSugar = 0;
            var max = 0.0;

            for (var i = 0; 100 * A * i <= F; i++)
            {
                for (var j = 0; 100 * A * i + 100 * B * j <= F; j++)
                {
                    var water = 100 * (A * i + B * j);
                    for (var k = 0; water + C * k <= F; k++)
                    {
                        for (var l = 0; water + C * k + D * l <= F; l++)
                        {
                            var sugar = C * k + D * l;
                            if (100 * sugar <= E * water)
                            {
                                var tmp = (double)(100 * sugar) / (water + sugar);
                                if (tmp > max)
                                {
                                    max = tmp;
                                    answerVolume = water + sugar;
                                    answerSugar = sugar;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"{answerVolume} {answerSugar}");
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
