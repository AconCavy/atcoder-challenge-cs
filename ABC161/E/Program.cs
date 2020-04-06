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
            // var nkc = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            // var s = Console.ReadLine();

            // var list = s.Select((x, index) => new { x, index }).Where(x => x.Equals('o')).ToList();
            // var tmpList = new List<List<int>>();

            // for (var i = 0; i < PermutationCount(nkc[0], nkc[1]); i++)
            // {

            // }
        }

        static long PermutationCount(int n, int k)
        {
            if (n < k) throw new ArgumentException();
            long result = n;
            for (var i = 1; i < k; i++)
                result *= (n - i);
            return result;
        }
    }
}
