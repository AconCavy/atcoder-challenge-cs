using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
2 7 2
",
            @"11
")]
        [TestCase(
            @"1
3
",
            @"3
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
2 1 2
2 2 3
2 1 3
",
            @"Yes
")]
        [TestCase(
            @"4 2
3 1 2 4
3 2 3 4
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
2 3 4
",
            @"6
")]
        [TestCase(
            @"2
1 0
",
            @"-1
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 1
",
            @"0 1 2
1 2 3
2 3 4
")]
        [TestCase(
            @"10 5
",
            @"0 3 2 3 2 3 4 5 4 5
3 4 1 2 3 4 3 4 5 6
2 1 4 3 2 3 4 5 4 5
3 2 3 2 3 4 3 4 5 6
2 3 2 3 4 3 4 5 4 5
3 4 3 4 3 4 5 4 5 6
4 3 4 3 4 5 4 5 6 5
5 4 5 4 5 4 5 6 5 6
4 5 4 5 4 5 6 5 6 7
5 6 5 6 5 6 5 6 7 6
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
-1 -1 -6
",
            @"2
2
0
")]
        [TestCase(
            @"5 6
-2 -2 -5 -7 -15
",
            @"1
3
2
0
0
0
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
