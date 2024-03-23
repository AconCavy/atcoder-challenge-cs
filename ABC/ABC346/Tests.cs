using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3
3 4 6
",
        @"12 24
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
22 75 26 45 72
",
        @"1650 1950 1170 3240
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 0
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"92 66
",
        @"Yes
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 5
1 6 3 1
",
        @"11
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 3
346
",
        @"6
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 158260522
877914575 24979445 623690081 262703497 24979445 1822804784 1430302156 1161735902 923078537 1189330739
",
        @"12523196466007058
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
00011
3 9 2 6 4
",
        @"7
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
1001
1 2 3 4
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"11
11111100111
512298012 821282085 543342199 868532399 690830957 973970164 928915367 954764623 923012648 540375785 925723427
",
        @"2286846953
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4 4
1 2 5
2 4 0
1 3 3
1 3 2
",
        @"3
0 5
2 4
5 3
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 1 5
1 1 1
1 1 10
2 1 100
1 1 1000
2 1 10000
",
        @"1
10000 1
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 5 10
1 1 1
1 2 2
1 3 3
1 4 4
1 5 5
2 1 6
2 2 7
2 3 8
2 4 9
2 5 10
",
        @"5
6 5
7 5
8 5
9 5
10 5
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
abc
ab
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
abc
arc
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"1000000000000
kzazkakxkk
azakxk
",
        @"344827586207
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
