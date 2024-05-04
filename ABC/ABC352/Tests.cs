using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"7 6 1 3
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 3 2 9
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"100 23 67 45
",
        @"Yes
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"abc
axbxyc
",
        @"1 3 6
",
        TestName = "{m}-1")]
    [TestCase(
        @"aaaa
bbbbaaaa
",
        @"5 6 7 8
",
        TestName = "{m}-2")]
    [TestCase(
        @"atcoder
atcoder
",
        @"1 2 3 4 5 6 7
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
4 10
5 8
2 9
",
        @"18
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
1 1
1 1
1 1
1 1
1 1
",
        @"5
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
690830957 868532399
741145463 930111470
612846445 948344128
540375785 925723427
723092548 925021315
928915367 973970164
563314352 832796216
562681294 868338948
923012648 954764623
691107436 891127278
",
        @"7362669937
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 2
2 3 1 4
",
        @"1
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 1
2 3 1 4
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 5
10 1 6 8 7 2 5 9 3 4
",
        @"5
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 3
3 3
1 2 3
2 2
1 2
3 4
1 3 4
",
        @"9
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 2
2 1
1 2
2 1
1 2
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 5
6 158260522
1 3 6 8 9 10
10 877914575
1 2 3 4 5 6 7 8 9 10
4 602436426
2 6 7 9
6 24979445
2 3 4 5 8 10
4 861648772
2 4 8 9
",
        @"1202115217
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 2
2 3 3
5 4 3
",
        @"3 -1 -1 -1 -1
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 0
",
        @"-1 -1 -1
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 5
6 7 3
8 1 7
4 5 1
7 2 1
6 2 4
",
        @"1 -1 -1 -1 -1 -1 -1 8
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
