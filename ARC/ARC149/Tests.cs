using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"7 12
",
            @"888888
")]
        [TestCase(
            @"9 12
",
            @"888888888
")]
        [TestCase(
            @"1 3
",
            @"9
")]
        [TestCase(
            @"1000 25
",
            @"-1
")]
        [TestCase(
            @"30 1
",
            @"999999999999999999999999999999
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
5 2 1 4 3
3 1 2 5 4
",
            @"8
")]
        [TestCase(
            @"5
1 2 3 4 5
1 2 3 4 5
",
            @"10
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
