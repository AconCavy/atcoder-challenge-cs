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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var (N, M) = (NM[0], NM[1]);
            var students = new (int X, int Y)[N];
            var checkPoints = new (int X, int Y)[M];
            for (var i = 0; i < N; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                students[i] = (ab[0], ab[1]);
            }
            for (var i = 0; i < M; i++)
            {
                var cd = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                checkPoints[i] = (cd[0], cd[1]);
            }
            for (var i = 0; i < N; i++)
            {
                var min = (long)1e18;
                var answer = 0;
                for (var j = 0; j < M; j++)
                {
                    var distance = Math.Abs(students[i].X - checkPoints[j].X) + Math.Abs(students[i].Y - checkPoints[j].Y);
                    if (distance < min)
                    {
                        min = distance;
                        answer = j;
                    }
                }
                Console.WriteLine(answer + 1);
            }
        }
    }
}
