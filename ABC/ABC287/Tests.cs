using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
For
Against
For
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"5
Against
Against
For
Against
For
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
For
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
            @"3 3
142857
004159
071028
159
287
857
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 4
235983
109467
823476
592801
000333
333
108
467
983
",
            @"3
",
            TestName = "{m}-2")]
        [TestCase(
            @"4 4
000000
123456
987111
000000
000
111
999
111
",
            @"3
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 3
1 3
4 2
3 2
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 0
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 5
1 2
2 3
3 4
4 5
5 1
",
            @"No
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"a?c
b?
",
            @"Yes
No
No
",
            TestName = "{m}-1")]
        [TestCase(
            @"atcoder
?????
",
            @"Yes
Yes
Yes
Yes
Yes
Yes
",
            TestName = "{m}-2")]
        [TestCase(
            @"beginner
contest
",
            @"No
No
No
No
No
No
No
No
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
abc
abb
aac
",
            @"2
2
1
",
            TestName = "{m}-1")]
        [TestCase(
            @"11
abracadabra
bracadabra
racadabra
acadabra
cadabra
adabra
dabra
abra
bra
ra
a
",
            @"4
3
2
1
0
1
0
4
3
2
1
",
            TestName = "{m}-2")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 2
2 3
3 4
",
            @"10
5
0
0
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
1 2
",
            @"3
0
",
            TestName = "{m}-2")]
        [TestCase(
            @"10
3 4
3 6
6 9
1 3
2 4
5 6
6 10
1 8
5 7
",
            @"140
281
352
195
52
3
0
0
0
0
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
