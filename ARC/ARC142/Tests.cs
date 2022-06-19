using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1420 142
",
            @"3
")]
        [TestCase(
            @"1419 142
",
            @"2
")]
        [TestCase(
            @"6 19
",
            @"0
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
",
            @"1 2
3 4
")]
        [TestCase(
            @"3
",
            @"1 2 3
5 4 6
7 8 9
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
