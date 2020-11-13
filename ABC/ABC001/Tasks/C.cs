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
            var (Deg, Dis) = Scanner.Scan<int, double>();
            var D = new[] { "N", "NNE", "NE", "ENE", "E", "ESE", "SE", "SSE", "S", "SSW", "SW", "WSW", "W", "WNW", "NW", "NNW" };
            var dir = D[(Deg * 10 + 1125) / 2250 % 16];

            int GetWindPower(double dis)
            {
                var ms = Math.Round(dis * 100 / 60);
                var str = ms.ToString();
                var b1 = str[str.Length - 1] - '0';
                ms -= b1;
                if (b1 >= 5) ms += 10;
                ms /= 10;
                if (ms <= 2) return 0;
                if (ms <= 15) return 1;
                if (ms <= 33) return 2;
                if (ms <= 54) return 3;
                if (ms <= 79) return 4;
                if (ms <= 107) return 5;
                if (ms <= 138) return 6;
                if (ms <= 171) return 7;
                if (ms <= 207) return 8;
                if (ms <= 244) return 9;
                if (ms <= 284) return 10;
                if (ms <= 326) return 11;
                return 12;
            }
            var w = GetWindPower(Dis);

            if (w == 0) dir = "C";
            Console.WriteLine($"{dir} {w}");
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
