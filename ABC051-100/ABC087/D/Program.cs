using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
{
    public class Program
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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NM[0];
            var M = NM[1];
            if (M == 0)
            {
                Console.WriteLine("Yes");
                return;
            }

            var LRD = new Info[M];
            var min = 0;
            for (var i = 0; i < M; i++)
            {
                var lrd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var l = lrd[0] - 1;
                var r = lrd[1] - 1;
                var d = lrd[2];
                if (l > r)
                {
                    var tmp = l;
                    l = r;
                    r = tmp;
                    d = -d;
                }
                LRD[i] = new Info { L = l, R = r, D = d };
            }

            LRD = LRD.OrderBy(x => x.L).ToArray();
            var points = Enumerable.Repeat(0, N).ToArray();
            points[LRD[0].L] = min;
            var checker = new bool[N];
            checker[LRD[0].L] = true;
            var answer = true;
            foreach (var info in LRD)
            {
                if (checker[info.R])
                {
                    if (checker[info.L])
                    {
                        if (points[info.R] != points[info.L] + info.D)
                        {
                            answer = false;
                            break;
                        }
                    }
                    else
                    {
                        points[info.L] = points[info.R] - info.D;
                        checker[info.L] = true;
                        min = Math.Min(min, points[info.L]);
                    }
                }
                else
                {
                    if (checker[info.L])
                    {
                        points[info.R] = points[info.L] + info.D;
                        checker[info.R] = true;
                        min = Math.Min(min, points[info.R]);
                    }
                    else
                    {
                    }
                }
            }

            // Console.WriteLine(string.Join(", ", points));

            if (answer)
            {
                foreach (var point in points)
                {
                    var p = point - min;
                    if (p > (int)1e9)
                    {
                        answer = false;
                        break;
                    }
                }
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }

        public class Info
        {
            public int L { get; set; }
            public int R { get; set; }
            public int D { get; set; }
        }
    }
}
