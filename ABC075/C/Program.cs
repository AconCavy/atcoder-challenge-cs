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
            var NM = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NM[0];
            var M = NM[1];
            var graph = new List<int>[N].Select(x => new List<int>()).ToArray();
            for (var i = 0; i < M; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                var a = ab[0] - 1;
                var b = ab[1] - 1;
                graph[a].Add(b);
                graph[b].Add(a);
            }

            var answer = 0;
            for (var i = 0; i < N; i++)
            {
                var ok = true;
                for (var j = 0; j < N; j++)
                {
                    if (graph[j].Count == 1)
                    {
                        var index = graph[j].First();
                        graph[index].Remove(j);
                        graph[j].Clear();
                        answer++;
                        ok = false;
                    }
                }
                if (ok) break;
            }
            Console.WriteLine(answer);
        }
    }
}
