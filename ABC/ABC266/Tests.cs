using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"atcoder
",
            @"o
")]
        [TestCase(
            @"a
",
            @"a
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"998244354
",
            @"1
")]
        [TestCase(
            @"-9982443534
",
            @"998244349
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"0 0
1 0
1 1
0 1
",
            @"Yes
")]
        [TestCase(
            @"0 0
1 1
-1 0
1 -1
",
            @"No
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 0 100
3 3 10
5 4 1
",
            @"101
")]
        [TestCase(
            @"3
1 4 1
2 4 1
3 4 1
",
            @"0
")]
        [TestCase(
            @"10
1 4 602436426
2 1 623690081
3 3 262703497
4 4 628894325
5 3 450968417
6 1 161735902
7 1 707723857
8 2 802329211
9 0 317063340
10 2 125660016
",
            @"2978279323
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1
",
            @"3.5000000000
")]
        [TestCase(
            @"2
",
            @"4.2500000000
")]
        [TestCase(
            @"10
",
            @"5.6502176688
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output, 1e-6);
        }
    }
}
