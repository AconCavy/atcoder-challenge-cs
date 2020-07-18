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
            var A = new string[N].Select(x => x = Console.ReadLine()).ToArray();
            var B = new string[M].Select(x => x = Console.ReadLine()).ToArray();
            var answer = true;
            for (var i = 0; i < N - M; i++)
            {
                for (var j = 0; j < N - M; j++)
                {
                    answer = true;
                    for (var y = 0; y < M; y++)
                    {
                        for (var x = 0; x < M; x++)
                        {
                            if (A[i + y][j + x] != B[y][x]) answer = false;
                            if (!answer) break;
                        }
                        if (!answer) break;
                    }
                    if (answer) break;
                }
                if (answer) break;
            }

            Console.WriteLine(answer ? "Yes" : "No");
        }
    }
}
