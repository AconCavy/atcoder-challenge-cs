using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace E
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
            var NK = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var N = NK[0];
            var K = NK[1];
            var A = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var p = (long)1e9 + 7;

            var plus = new List<long>();
            var minus = new List<long>();
            foreach (var a in A)
            {
                if (a >= 0) plus.Add(a);
                else minus.Add(a);
            }

            var ok = false;
            if (plus.Count > 0) ok = N == K ? (minus.Count % 2 == 0) : true;
            else ok = K % 2 == 0;

            var answer = 1L;
            var items = new List<long>();
            if (!ok)
            {
                items = A.OrderBy(x => Math.Abs(x)).Take(K).ToList();
            }
            else
            {
                var pQ = new Queue<long>(plus.OrderByDescending(x => x));
                var mQ = new Queue<long>(minus.OrderBy(x => x));
                if (K % 2 == 1) answer = pQ.Dequeue() % p;
                items = new List<long>();
                while (pQ.Count() > 1) items.Add((pQ.Dequeue() * pQ.Dequeue()) % p);
                while (mQ.Count() > 1) items.Add((mQ.Dequeue() * mQ.Dequeue()) % p);
                items = items.OrderByDescending(x => x).Take(K / 2).ToList();
            }

            foreach (var item in items)
            {
                answer *= item;
                answer %= p;
            }
            if (answer < 0) answer = (answer + p) % p;
            Console.WriteLine(answer);
        }
    }
}
