using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
abcde
",
            @"e
")]
        [TestCase(
            @"1
a
",
            @"a
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
SSRS
",
            @"2 -1
")]
        [TestCase(
            @"20
SRSRSSRSSSRSRRRRRSRR
",
            @"0 1
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"R G B
R G B
",
            @"Yes
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 4 4 1 3 2
1 2
2 3
3 4
1 4
",
            @"4
")]
        [TestCase(
            @"6 5 10 1 2 3
2 3
2 4
4 6
3 6
1 5
",
            @"0
")]
        [TestCase(
            @"10 15 20 4 4 6
2 6
2 7
5 7
4 5
2 4
3 7
1 7
1 4
2 9
5 10
1 3
7 8
7 9
1 6
1 2
",
            @"952504739
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 2
1 2
2 3
",
            @"14
")]
        [TestCase(
            @"5 5
4 2
2 3
1 3
2 1
1 5
",
            @"108
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
