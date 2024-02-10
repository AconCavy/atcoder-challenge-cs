using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3 9 2
",
        @"3 5 7 9
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 10 1
",
        @"10
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
1 20
1 30
2 1
1 40
2 3
",
        @"30
20
",
        TestName = "{m}-1")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"340
",
        @"2888
",
        TestName = "{m}-2")]
    [TestCase(
        @"100000000000000000
",
        @"5655884811924144128
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
100 200 3
50 10 1
100 200 5
150 1 2
",
        @"350
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
1000 10 9
1000 10 10
1000 10 2
1000 10 3
1000 10 4
1000 10 5
1000 10 6
1000 10 7
1000 10 8
",
        @"90
",
        TestName = "{m}-2")]
    [TestCase(
        @"6
1000000000 1000000000 1
1000000000 1000000000 1
1000000000 1000000000 1
1000000000 1000000000 1
1000000000 1000000000 1
",
        @"5000000000
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 3
1 2 3 4 5
2 4 0
",
        @"0 4 2 7 2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 10
1000000000 1000000000 1000000000
0 1 0 1 0 1 0 1 0 1
",
        @"104320141 45436840 2850243019
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 4
1
0 0 0 0
",
        @"1
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 5
",
        @"1 1
",
        TestName = "{m}-1")]
    [TestCase(
        @"-2 0
",
        @"0 1
",
        TestName = "{m}-2")]
    [TestCase(
        @"8752654402832944 -6857065241301125
",
        @"-1
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
