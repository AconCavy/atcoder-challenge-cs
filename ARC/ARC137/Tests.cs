using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2 4
",
            @"1
")]
        [TestCase(
            @"14 21
",
            @"5
")]
        [TestCase(
            @"1 100
",
            @"99
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
0 1 1 0
",
            @"4
")]
        [TestCase(
            @"5
0 0 0 0 0
",
            @"6
")]
        [TestCase(
            @"6
0 1 0 1 0 1
",
            @"3
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
2 4
",
            @"Alice
")]
        [TestCase(
            @"3
0 1 2
",
            @"Bob
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output, 1e9);
        }
    }
}
