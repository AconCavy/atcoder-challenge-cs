using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 3 3 6 2 5 10
",
            @"Takahashi
")]
        [TestCase(
            @"3 1 4 1 5 9 2
",
            @"Aoki
")]
        [TestCase(
            @"1 1 1 1 1 1 1
",
            @"Draw
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"AtCoder
",
            @"Yes
")]
        [TestCase(
            @"Aa
",
            @"Yes
")]
        [TestCase(
            @"atcoder
",
            @"No
")]
        [TestCase(
            @"Perfect
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
abi
aef
bc
acg
",
            @"3
")]
        [TestCase(
            @"2 2
a
b
",
            @"0
")]
        [TestCase(
            @"5 2
abpqxyz
az
pq
bc
cy
",
            @"7
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
6 2 3
",
            @"2
")]
        [TestCase(
            @"1
2
",
            @"0
")]
        [TestCase(
            @"10
1 3 2 4 6 8 2 2 3 7
",
            @"62
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"3 998244353
",
            @"26
")]
        [TestCase(
            @"2 998244353
",
            @"0
")]
        [TestCase(
            @"5 998244353
",
            @"2626
")]
        [TestCase(
            @"3000 924844033
",
            @"607425699
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 1
2 4
2 -3
1 2
2 1
2 -3
",
            @"3
")]
        [TestCase(
            @"1 0
2 -1000000000
",
            @"-1000000000
")]
        [TestCase(
            @"10 3
2 3
2 -1
1 4
2 -1
2 5
2 -9
2 2
1 -6
2 5
2 -3
",
            @"15
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
