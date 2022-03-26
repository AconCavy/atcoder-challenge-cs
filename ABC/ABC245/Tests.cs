using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"7 0 6 30
",
            @"Aoki
")]
        [TestCase(
            @"7 30 7 30
",
            @"Takahashi
")]
        [TestCase(
            @"0 0 23 59
",
            @"Takahashi
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"8
0 3 2 6 2 1 0 0
",
            @"4
")]
        [TestCase(
            @"8
0 3 2 6 2 1 0 0
",
            @"4
")]
        [TestCase(
            @"3
2000 2000 2000
",
            @"0
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4
9 8 3 7 2
1 6 2 9 5
",
            @"Yes
")]
        [TestCase(
            @"4 90
1 1 1 100
1 2 3 100
",
            @"No
")]
        [TestCase(
            @"4 1000000000
1 1 1000000000 1000000000
1 1000000000 1 1000000000
",
            @"Yes
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 2
2 1
12 14 8 2
",
            @"6 4 2
")]
        [TestCase(
            @"1 1
100 1
10000 0 -1
",
            @"100 -1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
2 4
3 2
8 1 5
2 10 5
",
            @"Yes
")]
        [TestCase(
            @"2 2
1 1
2 2
100 1
100 1
",
            @"No
")]
        [TestCase(
            @"1 1
10
100
100
10
",
            @"No
")]
        [TestCase(
    @"1 1
10
100
10
100
",
@"Yes
"
)]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5
1 2
2 3
3 4
4 2
4 5
",
            @"4
")]
        [TestCase(
            @"3 2
1 2
2 1
",
            @"2
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
