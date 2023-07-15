using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 100 50
60 20 40
",
            @"70
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 100 50
60000 20000 40000
",
            @"100
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 6
10000 2 1 3
15000 3 1 2 4
30000 3 1 3 5
35000 2 1 5
100000 6 1 2 3 4 5 6
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 4
3 1 1
3 1 2
3 1 2
4 2 2 3
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"20 10
72036 3 3 4 9
7716 4 1 2 3 6
54093 5 1 6 7 8 10
25517 7 3 4 5 6 7 9 10
96930 8 2 3 4 6 7 8 9 10
47774 6 2 4 5 6 7 9
36959 5 1 3 4 5 8
46622 7 1 2 3 5 6 8 10
34315 9 1 3 4 5 6 7 8 9 10
54129 7 1 3 4 6 7 8 9
4274 5 2 4 7 9 10
16578 5 2 3 6 7 9
61809 4 1 2 4 5
1659 5 3 5 6 9 10
59183 5 1 2 3 4 9
22186 4 3 5 6 8
98282 4 1 4 7 10
72865 8 1 2 3 4 6 8 9 10
33796 6 1 3 5 7 9 10
74670 4 1 2 6 8
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
            @"6
a
abc
de
cba
de
abc
",
            @"3
",
            TestName = "{m}-1")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 2 2
1 3
3 4
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 1 2
1 3
3 4
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 4 0
",
            @"65
",
            TestName = "{m}-3")]
        [TestCase(
            @"10 6 8
5 9
1 4
3 8
1 6
4 10
5 7
5 6
3 7
",
            @"8001
",
            TestName = "{m}-4")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
00110
",
            @"9
",
            TestName = "{m}-1")]
        [TestCase(
            @"30
101010000100101011010011000010
",
            @"326
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
