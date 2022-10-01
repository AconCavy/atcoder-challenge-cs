using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"99
",
            @"63
")]
        [TestCase(
            @"12
",
            @"0C
")]
        [TestCase(
            @"0
",
            @"00
")]
        [TestCase(
    @"255
",
    @"FF
"
)]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2
3 1 4 7
2 5 9
1 3
2 1
",
            @"7
5
")]
        [TestCase(
            @"3 4
4 128 741 239 901
2 1 1
3 314 159 26535
1 1
2 2
3 3
1 4
",
            @"128
1
26535
901
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
1 2 4 6 7 271
",
            @"4
")]
        [TestCase(
            @"10
1 1 1 1 1 1 1 1 1 1
",
            @"5
")]
        [TestCase(
            @"1
5
",
            @"0
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 11
1 4
2 3
5 7
",
            @"Yes
THH
")]
        [TestCase(
            @"5 25
2 8
9 3
4 11
5 1
12 6
",
            @"No
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4 4
1 2 2
2 3 2
1 3 3
1 3 5
4 2 1 2
",
            @"4
")]
        [TestCase(
            @"3 2 3
1 2 1
2 3 1
2 1 1
",
            @"-1
")]
        [TestCase(
            @"4 4 5
3 2 2
1 3 5
2 4 7
3 4 10
2 4 1 4 3
",
            @"14
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
