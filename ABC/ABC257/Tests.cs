using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 3
",
            @"C
")]
        [TestCase(
            @"2 12
",
            @"F
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3 5
1 3 4
3 3 1 1 2
",
            @"2 4 5
")]
        [TestCase(
            @"2 2 2
1 2
1 2
",
            @"1 2
")]
        [TestCase(
            @"10 6 9
1 3 5 7 8 9
1 2 3 4 5 6 5 6 2
",
            @"2 5 6 7 9 10
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
10101
60 45 30 40 80
",
            @"4
")]
        [TestCase(
            @"3
000
1 2 3
",
            @"3
")]
        [TestCase(
            @"5
10101
60 50 50 50 60
",
            @"4
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
-10 0 1
0 0 5
10 0 1
11 0 1
",
            @"2
")]
        [TestCase(
            @"7
20 31 1
13 4 3
-10 -15 2
34 26 5
-2 39 4
0 -50 1
5 -20 2
",
            @"18
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
5 4 3 3 2 5 3 5 3
",
            @"95
")]
        [TestCase(
            @"20
1 1 1 1 1 1 1 1 1
",
            @"99999999999999999999
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
