using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"2 5
",
        @"0
",
        TestName = "{m}-1")]
    [TestCase(
        @"0 0
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"7 1
",
        @"0
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
0 1 1 0
1 0 0 1
1 0 0 0
0 1 0 0
",
        @"2 3
1 4
1
2
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
0 0
0 0
",
        @"
",
        TestName = "{m}-2")]
    [TestCase(
        @"5
0 1 0 1 1
1 0 0 1 0
0 0 0 0 1
1 1 0 0 1
1 0 1 1 0
",
        @"2 4 5
1 4
5
1 2 5
1 3 4
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"345
",
        @"343
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"123456789012345
",
        @"1334996994331
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4
1 10
3 20
2 10
2 10
",
        @"2
3
2
2
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 3
1 3
1 4
1 3
",
        @"1
1
1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 10
7 2620
9 2620
8 3375
1 3375
6 1395
5 1395
6 2923
10 3375
9 5929
5 1225
",
        @"2
2
3
3
4
4
5
5
6
5
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"840 84 7
",
        @"Yes
0 0 0 0 6 0 6 0 0
",
        TestName = "{m}-1")]
    [TestCase(
        @"343 34 3
",
        @"No
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 4
3 3 1 4 5
2 1 3
2 5 5
1 3 3
2 2 4
",
        @"1
0
2
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 1
1000000000
2 1 1
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 9
2 4 4 3 9 1 1 2
1 5 4
2 7 7
2 2 6
1 4 4
2 2 5
2 2 7
1 1 1
1 8 1
2 1 8
",
        @"0
1
0
2
4
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
