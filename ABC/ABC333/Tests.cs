using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3
",
        @"333
",
        TestName = "{m}-1")]
    [TestCase(
        @"9
",
        @"999999999
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"AC
EC
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"DA
EA
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"BD
BD
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
        @"5
",
        @"113
",
        TestName = "{m}-1")]
    [TestCase(
        @"19
",
        @"2333
",
        TestName = "{m}-2")]
    [TestCase(
        @"333
",
        @"112222222233
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"9
1 2
2 3
2 4
2 5
1 6
6 7
7 8
7 9
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
1 2
2 3
2 4
3 5
3 6
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"24
3 6
7 17
7 20
7 11
14 18
17 21
6 19
5 22
9 24
11 14
6 23
8 17
9 12
4 17
2 15
1 17
3 9
10 16
7 13
2 16
1 16
5 7
1 3
",
        @"12
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"13
1 2
1 3
1 1
1 3
1 2
2 3
1 3
1 3
2 3
1 3
2 2
2 3
2 1
",
        @"3
1 1 1 0 0 1 0 1
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
2 3
1 4
2 1
1 2
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"30
1 25
1 2
1 10
1 18
2 18
1 11
2 11
1 21
1 6
2 2
2 10
1 11
1 24
1 11
1 3
1 2
1 18
2 25
1 8
1 10
1 11
2 18
2 10
1 10
2 2
1 24
1 10
2 10
1 25
2 6
",
        @"4
1 1 1 1 1 1 0 1 1 0 0 0 0 1 0 0 1 0 0 0
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2
",
        @"332748118 665496236
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
",
        @"235530465 792768557 258531487 238597268 471060930
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
