using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"54
",
        @"6
",
        TestName = "{m}-1")]
    [TestCase(
        @"7
",
        @"4
",
        TestName = "{m}-2")]
    [TestCase(
        @"262144
",
        @"19
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
takahashi 2
aoki 6
snuke 5
",
        @"snuke
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
takahashi 2813
takahashixx 1086
takahashix 4229
",
        @"takahashix
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
2 4
1 1
3 2
",
        @"2
2 3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
1 1
10 2
100 3
1000 4
10000 5
",
        @"5
1 2 3 4 5
",
        TestName = "{m}-2")]
    [TestCase(
        @"6
32 101
65 78
2 29
46 55
103 130
52 40
",
        @"4
2 3 5 6
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"0 0 3 3
",
        @"10
",
        TestName = "{m}-1")]
    [TestCase(
        @"-1 -2 1 3
",
        @"11
",
        TestName = "{m}-2")]
    [TestCase(
        @"-1000000000 -1000000000 1000000000 1000000000
",
        @"4000000000000000000
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
1 9
2 5
4 9
1 4
2 5
",
        @"Aoki
",
        TestName = "{m}-1")]
    [TestCase(
        @"9
3 2
1 7
4 1
1 8
5 2
9 8
2 1
6 8
5 2
",
        @"Takahashi
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
