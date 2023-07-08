using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"7 8
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 9
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 4
",
            @"No",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
0101
1101
1111
0000
",
            @"1010
1101
0111
0001
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
11
11
",
            @"11
11
",
            TestName = "{m}-2")]
        [TestCase(
            @"5
01010
01001
10110
00110
01010
",
            @"00101
11000
00111
00110
10100
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 8
6 3
2 5
1 9
4 2
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 100
6 3
2 5
1 9
4 2
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"15 158260522
877914575 2436426
24979445 61648772
623690081 33933447
476190629 62703497
211047202 71407775
628894325 31963982
822804784 50968417
430302156 82631932
161735902 80895728
923078537 7723857
189330739 10286918
802329211 4539679
303238506 17063340
492686568 73361868
125660016 50287940
",
            @"492686569
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4 6
1 2
2 3
4 5
4 6
1 3
6 7
",
            @"5
",
            TestName = "{m}-1")]
        [TestCase(
            @"7 5 20
10 11
4 5
10 12
1 2
1 5
5 6
2 4
3 5
9 10
2 5
1 4
11 12
9 12
8 9
5 7
3 7
3 6
3 4
8 12
9 11
",
            @"4
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7 3
1 2 1 3 3 3
1 1
1 2
4 3
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"10 10
1 1 3 1 2 3 3 5 7
2 1
5 1
4 3
6 3
2 1
7 3
9 2
1 2
6 2
8 1
",
            @"10
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2500)]
        [TestCase(
            @"3
19 8 22
10 24 12
15 25 11
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
19 8 22
10 25 12
15 24 11
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"2
1 1 2
1 2 2
",
            @"No
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
