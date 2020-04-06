using System;
using System.Linq;

namespace C
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split(' ');
            var k = int.Parse(input[0]);
            var an = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Array.Sort(an);

            var gap = k - an[an.Length - 1];
            var index = an.Length - 1;

            for (var i = 0; i < an.Length - 1; i++)
            {

                var tmp = an[i + 1] - an[i];

                if (tmp > gap)
                {
                    gap = tmp;
                    index = i;
                }
            }
            var sum = 0;
            if (index < 1 || index >= an.Length - 1)
            {
                sum = an[an.Length - 1] - an[0];
            }
            else
            {
                sum = k - an[index + 1] + an[index];
            }

            Console.WriteLine(sum);
        }
    }
}
