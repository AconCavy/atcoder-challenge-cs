using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 1
abac
",
            @"2
")]
        [TestCase(
            @"10 0
aaaaaaaaaa
",
            @"1
")]
        [TestCase(
            @"6 1
abcaba
",
            @"3
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
AARCCC
",
            @"2
")]
        [TestCase(
            @"5
AAAAA
",
            @"0
")]
        [TestCase(
            @"9
ARCARCARC
",
            @"3
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
",
            @"2 1 3
")]
        [TestCase(
            @"3 1
",
            @"1 2 3
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
