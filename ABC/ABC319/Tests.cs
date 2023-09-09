using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"tourist
",
        @"3858
",
        TestName = "{m}-1")]
    [TestCase(
        @"semiexp
",
        @"3481
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"12
",
        @"1-643-2-346-1
",
        TestName = "{m}-1")]
    [TestCase(
        @"7
",
        @"17777771
",
        TestName = "{m}-2")]
    [TestCase(
        @"1
",
        @"11
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 1 9
2 5 6
2 7 1
",
        @"0.666666666666666666666666666667
",
        TestName = "{m}-1")]
    [TestCase(
        @"7 7 6
8 6 8
7 7 6
",
        @"0.004982363315696649029982363316
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 6 7
1 9 7
5 7 5
",
        @"0.4
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output, 1e-8);
    }

    [Timeout(2000)]
    [TestCase(
        @"13 3
9 5 2 7 1 8 8 2 1 5 2 3 6
",
        @"26
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 1
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
",
        @"10000000009
",
        TestName = "{m}-2")]
    [TestCase(
        @"30 8
8 55 26 97 48 37 47 35 55 5 17 62 2 60 23 99 73 34 75 7 46 82 84 29 41 32 31 52 32 60
",
        @"189
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 2 3
5 4
6 6
3 1
7
13
0
710511029
136397527
763027379
644706927
447672230
",
        @"34
22
710511052
136397548
763027402
644706946
447672250
",
        TestName = "{m}-1")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
