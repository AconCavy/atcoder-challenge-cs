using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4
0 1 3 2
",
            @"12
")]
        [TestCase(
            @"5
4 3 2 1 0
",
            @"31
")]
        [TestCase(
            @"1
40
",
            @"1099511627776
")]
        [TestCase(
            @"8
2 0 2 2 0 4 2 4
",
            @"80
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
10 3 5 2 3 6
10 3 5 1 1000000000 1000000000
139 2 139 1 1 1
139 1 1 1 1 1
139 7 10 3845 26982 30923
",
            @"11
10
1
139
436604
")]
        [TestCase(
            @"8
1000000000 1 1 1000000000 1000000000 1000000000
1000000000 1 2 1000000000 1000000000 1000000000
5 6 8 10 10 10
1 100 10 10000 100 10
5 2 3 10 5 3
10 2 3 2 4 6
10 2 6 6 11 29
13 2 3 5 7 11
",
            @"1000000000000000000
500000000000000000
50
10000
8
20
51
46
"
        )]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
