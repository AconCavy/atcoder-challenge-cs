using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
",
            @"6
3
")]
        [TestCase(
            @"6
",
            @"12
24
")]
        [TestCase(
            @"100
",
            @"200
4444444444444444444444444
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2 2
1 5 9
",
            @"5
")]
        [TestCase(
            @"3 2 3
11 1 2
",
            @"3
")]
        [TestCase(
            @"3 1 100
8 5 6
",
            @"5
")]
        [TestCase(
            @"6 123 321
10 100 1000 10000 100000 1000000
",
            @"90688
")]
        [TestCase(
            @"2 1 2
1 3
",
            @"1")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 1
",
            @"2 3 1
")]
        [TestCase(
            @"8 3
",
            @"4 5 6 7 8 1 2 3
")]
        [TestCase(
            @"8 6
",
            @"-1
")]
        public void taskTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
