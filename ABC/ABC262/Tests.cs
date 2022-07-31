using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2022
",
            @"2022
")]
        [TestCase(
            @"2023
",
            @"2026
")]
        [TestCase(
            @"3000
",
            @"3002
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 6
1 5
4 5
2 3
1 4
3 5
2 5
",
            @"2
")]
        [TestCase(
            @"3 1
1 2
",
            @"0
")]
        [TestCase(
            @"7 10
1 7
5 7
2 5
3 6
4 7
1 5
2 4
1 3
1 6
2 7
",
            @"4
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 3 2 4
",
            @"2
")]
        [TestCase(
            @"10
5 8 2 2 1 6 7 2 9 10
",
            @"8
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2500)]
        [TestCase(
            @"3
2 6 2
",
            @"6
")]
        [TestCase(
            @"5
5 5 5 5 5
",
            @"31
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
