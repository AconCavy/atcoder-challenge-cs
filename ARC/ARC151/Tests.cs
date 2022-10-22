using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
00100
10011
",
            @"00001
")]
        [TestCase(
            @"1
0
1
",
            @"-1
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
