using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4
3 2
1??
4 2
?1?0
6 3
011?1?
10 5
00?1???10?
",
            @"Yes
No
No
Yes
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
