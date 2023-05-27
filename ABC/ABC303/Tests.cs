using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
l0w
1ow
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
abc
arc
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"4
nok0
n0ko
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
            @"4 2
1 2 3 4
4 3 1 2
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3
1 2 3
3 1 2
1 2 3
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 10
4 10 7 2 8 3 9 1 6 5
3 6 2 9 1 8 10 7 4 5
9 3 4 5 7 10 1 8 2 6
7 3 1 8 4 9 5 6 2 10
5 2 1 4 10 7 9 8 3 6
5 8 1 6 9 3 2 4 7 10
8 10 3 4 5 7 2 9 6 1
3 10 2 7 8 5 1 4 9 6
10 6 1 5 4 2 3 8 9 7
4 5 9 1 8 2 7 6 3 10
",
            @"6
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2 3 1
RUDL
-1 -1
1 0
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 2 1 5
LDRLD
0 0
-1 -1
",
            @"No
",
            TestName = "{m}-2")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 3 3
AAaA
",
            @"9
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 1 100
aAaAaA
",
            @"6
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 2 4
aaAaAaaAAAAaAaaAaAAaaaAAAAA
",
            @"40
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
1 2
2 3
3 4
4 5
5 6
",
            @"2 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"9
3 9
7 8
8 6
4 6
4 1
5 9
7 3
5 2
",
            @"2 2 2
",
            TestName = "{m}-2")]
        [TestCase(
            @"20
8 3
8 18
2 19
8 20
9 17
19 7
8 7
14 12
2 15
14 10
2 13
2 16
2 1
9 5
10 15
14 6
2 4
2 11
5 12
",
            @"2 3 4 7
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
