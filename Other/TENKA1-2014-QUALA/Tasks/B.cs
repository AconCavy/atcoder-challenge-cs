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
            var N = S.Length;
            var count = new int[N + 10];
            var damage = new long[N + 10];
            var combo = new int[N + 10];
            var charge = new bool[N + 10];

            var curr = 5;
            var isCharging = false;

            long Damage(long d, long c) => d + d * (c / 10) / 10;

            for (var i = 0; i < N; i++)
            {
                curr += count[i];
                if (i > 0) combo[i] += combo[i - 1];
                if (charge[i] == true) isCharging = false;
                if (isCharging) continue;

                if (S[i] == 'N' && curr >= 1)
                {
                    count[i + 7] += 1;
                    damage[i + 2] += Damage(10, combo[i]);
                    combo[i + 2] += 1;
                    curr -= 1;
                    isCharging = true;
                    charge[i + 1] = true;
                }

                if (S[i] == 'C' && curr >= 3)
                {
                    count[i + 9] += 3;
                    damage[i + 4] += Damage(50, combo[i]);
                    combo[i + 4] += 1;
                    curr -= 3;
                    isCharging = true;
                    charge[i + 3] = true;
                }
            }

            var answer = damage.Sum();
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
