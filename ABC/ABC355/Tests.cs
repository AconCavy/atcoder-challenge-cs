using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"1 2
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 1
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 1
",
        @"2
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
3 2 5
4 1
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 2
3 1 5
4 2
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 1
1
2
",
        @"No
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 5
5 1 8 9 7
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 5
4 2 9 7 5
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"4 12
13 9 6 5 2 7 16 14 8 3 10 11
",
        @"9
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
1 5
7 8
3 7
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
3 4
2 5
1 6
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"2
1 2
3 4
",
        @"0
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 4
1 2 6
2 3 5
2 4 4
1 3 3
1 2 3
1 4 10
3 4 1
",
        @"12
10
10
7
",
        TestName = "{m}-1")]
    [TestCase(
        @"8 6
1 8 8
1 6 10
1 5 8
2 6 6
6 7 6
1 3 9
2 4 7
1 3 4
1 6 7
3 4 6
1 5 1
7 8 4
3 5 3
",
        @"49
46
45
38
34
33
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
