using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
3
101
6
101101
5
11111
6
000000
30
111011100110101100101000000111
",
            @"1
2
-1
0
8
",
            TestName = "{m}-1")]
        [TestCase(
            @"14
4
1100
4
0011
4
1111
5
00000
5
10111
3
000
3
001
3
010
3
011
3
100
3
101
3
110
3
111
4
0110
",
            @"2
2
2
0
2
0
-1
-1
-1
-1
1
-1
-1
3
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 1
0 1 3
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 1
0 0
",
            @"2
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 10
3 1 4 1 5
",
            @"7109
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
