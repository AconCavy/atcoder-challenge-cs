using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"hello2023
",
        @"hello2024
",
        TestName = "{m}-1")]
    [TestCase(
        @"worldtourfinals2023
",
        @"worldtourfinals2024
",
        TestName = "{m}-2")]
    [TestCase(
        @"2023
",
        @"2024
",
        TestName = "{m}-3")]
    [TestCase(
        @"20232023
",
        @"20232024
",
        TestName = "{m}-4")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
",
        @"0 0 0
0 0 1
0 0 2
0 0 3
0 1 0
0 1 1
0 1 2
0 2 0
0 2 1
0 3 0
1 0 0
1 0 1
1 0 2
1 1 0
1 1 1
1 2 0
2 0 0
2 0 1
2 1 0
3 0 0
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
",
        @"0 0 0
0 0 1
0 0 2
0 0 3
0 0 4
0 1 0
0 1 1
0 1 2
0 1 3
0 2 0
0 2 1
0 2 2
0 3 0
0 3 1
0 4 0
1 0 0
1 0 1
1 0 2
1 0 3
1 1 0
1 1 1
1 1 2
1 2 0
1 2 1
1 3 0
2 0 0
2 0 1
2 0 2
2 1 0
2 1 1
2 2 0
3 0 0
3 0 1
3 1 0
4 0 0
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 9
2 3
1 U
2 3
1 R
1 D
2 3
1 L
2 1
2 5
",
        @"3 0
2 0
1 1
1 0
1 0
",
        TestName = "{m}-1")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
",
        @"1 2 3 4 5
16 17 18 19 6
15 24 T 20 7
14 23 22 21 8
13 12 11 10 9
",
        TestName = "{m}-1")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 6
10 20 30 40 50
1 2
1 3
2 5
3 4
3 5
4 5
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 5
1 10 11 4
1 2
1 3
2 3
2 4
3 4
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 12
1 2 3 3 4 4 4 6 5 7
1 3
2 9
3 4
5 6
1 2
8 9
4 5
8 10
7 10
4 6
2 8
6 7
",
        @"5
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
