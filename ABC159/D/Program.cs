using System;
using System.Collections.Generic;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray()[0];
            var a = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var countDict = new Dictionary<int, int>();
            Func<int, long> comb = num => num < 1 ? 0 : (num * (num - 1)) / 2;

            for (var i = 0; i < a.Length; i++)
            {
                var ai = a[i];
                if (countDict.ContainsKey(ai))
                {
                    countDict[ai]++;
                    continue;
                }
                countDict.Add(ai, 1);
            }


            foreach (var ai in a)
            {
                Console.WriteLine(comb(countDict[ai]));
            }
        }
    }
}
