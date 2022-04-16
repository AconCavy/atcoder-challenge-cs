using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"023456789
",
            @"1
")]
        [TestCase(
            @"459230781
",
            @"6
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 4 2
",
            @"2
")]
        [TestCase(
            @"7 7 10
",
            @"0
")]
        [TestCase(
            @"31 415926 5
",
            @"6
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 4
",
            @"6
")]
        [TestCase(
            @"31 41 592
",
            @"798416518
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
3 1 4 1 5
4
1 5 1
2 4 3
1 5 2
1 3 3
",
            @"2
0
0
1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 2
0 0
1 0
0 1
-1 0
0 -1
",
            @"6
")]
        [TestCase(
            @"1 1
0 0
",
            @"Infinity
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
