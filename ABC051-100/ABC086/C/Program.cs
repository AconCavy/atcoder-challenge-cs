using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var N = int.Parse(Console.ReadLine());
            var prevT = 0;
            var prevX = 0;
            var prevY = 0;
            var isValid = true;
            var infos = new int[N][];
            for (var i = 0; i < N; i++)
            {
                infos[i] = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            }
            foreach (var info in infos)
            {
                var t = info[0];
                var x = info[1];
                var y = info[2];
                var dt = t - prevT;
                var dx = Math.Abs(x - prevX);
                var dy = Math.Abs(y - prevY);

                if (dx + dy > dt || (dx + dy) % 2 != dt % 2)
                {
                    isValid = false;
                    break;
                }
                prevT = t;
                prevX = x;
                prevY = y;
            }

            Console.WriteLine(isValid ? "Yes" : "No");
        }
    }
}
