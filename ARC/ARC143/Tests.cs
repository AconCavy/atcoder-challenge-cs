using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2 2 3
",
            @"3
")]
        [TestCase(
            @"0 0 1
",
            @"-1
")]
        [TestCase(
            @"0 0 0
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
            @"8
")]
        [TestCase(
            @"5
",
            @"704332752
")]
        [TestCase(
            @"100
",
            @"927703658
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
