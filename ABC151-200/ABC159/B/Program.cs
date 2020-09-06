using System;
namespace B
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine().Trim();
            Func<string, bool> func = str =>
            {
                if (str.Length == 1) return true;
                for (var i = 0; i < str.Length / 2; i++)
                    if (str[i] != str[str.Length - 1 - i])
                        return false;
                return true;
            };

            var n = s.Length;
            Console.WriteLine(func(s) && func(s.Substring(0, ((n - 1) / 2))) ? "Yes" : "No");
        }
    }
}
