using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"Wednesday
",
            @"3
")]
        [TestCase(
            @"Monday
",
            @"5
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"0101110101
",
            @"Yes
")]
        [TestCase(
            @"0100101001
",
            @"Yes
")]
        [TestCase(
            @"0000100110
",
            @"No
")]
        [TestCase(
            @"1101110101
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2
5 4 -1 8
",
            @"15
")]
        [TestCase(
            @"10 4
-3 1 -4 1 -5 9 -2 6 -5 3
",
            @"31
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2
5 4 -1 8
",
            @"21
")]
        [TestCase(
            @"10 4
-3 1 -4 1 -5 9 -2 6 -5 3
",
            @"54
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(4000)]
        [TestCase(
            @"4 3
3 1 4 2
1 2
1 3
4 1
",
            @"3
")]
        [TestCase(
            @"7 13
464 661 847 514 74 200 188
5 1
7 1
5 7
4 1
4 5
2 4
5 2
1 3
1 6
3 5
1 2
4 6
2 7
",
            @"1199
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
