using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"2 2000 500
1000 1
100 6
",
        @"2100
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 2000 500
1000 1
100 6
5000 1
",
        @"6600
",
        TestName = "{m}-2")]
    [TestCase(
        @"2 2000 500
1000 1
1000 1
",
        @"2000
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 300 500
",
        @"200 500
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 100 200
",
        @"0 0
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6 1
112022
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1
222
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"2 1
01
",
        @"0
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 5
1 2 3 4 5
6 7 8 9 10
11 12 13 14 15
16 17 18 19 20
1 3 2 5 4
11 13 12 15 14
6 8 7 10 9
16 18 17 20 19
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 2
1 1
1 1
1 1
1 1000000000
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 3
8 1 6
3 5 7
4 9 2
8 1 6
3 5 7
4 9 2
",
        @"0
",
        TestName = "{m}-3")]
    [TestCase(
        @"5 5
710511029 136397527 763027379 644706927 447672230
979861204 57882493 442931589 951053644 152300688
43971370 126515475 962139996 541282303 834022578
312523039 506696497 664922712 414720753 304621362
325269832 191410838 286751784 732741849 806602693
806602693 732741849 286751784 191410838 325269832
304621362 414720753 664922712 506696497 312523039
834022578 541282303 962139996 126515475 43971370
152300688 951053644 442931589 57882493 979861204
447672230 644706927 763027379 136397527 710511029
",
        @"20
",
        TestName = "{m}-4")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 3
3 5 3 6 3
",
        @"0.888888888888889
",
        TestName = "{m}-1")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output, 1e-6);
    }
}
