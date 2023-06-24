using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2
1000 2000 3000 4000 5000 6000 7000 2000 3000 4000 5000 6000 7000 8000
",
            @"28000 35000
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
14159 26535 89793 23846 26433 83279 50288 41971 69399 37510 58209 74944 59230 78164 6286 20899 86280 34825 34211 70679 82148
",
            @"314333 419427 335328
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
ab
ccef
da
a
fe
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
a
b
aba
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"2
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
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
            @"3 5
#.#..
.....
.#...
2 2
#.
.#
5 3
...
#.#
.#.
.#.
...
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 2
#.
.#
2 2
#.
.#
2 2
##
##
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 1
#
1 2
##
1 1
#
",
            @"No
",
            TestName = "{m}-3")]
        [TestCase(
            @"3 3
###
...
...
3 3
#..
#..
#..
3 3
..#
..#
###
",
            @"Yes
",
            TestName = "{m}-4")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"8
a(b(d))c
",
            @"ac
",
            TestName = "{m}-1")]
        [TestCase(
            @"5
a(b)(
",
            @"a(
",
            TestName = "{m}-2")]
        [TestCase(
            @"2
()
",
            @"
",
            TestName = "{m}-3")]
        [TestCase(
            @"6
)))(((
",
            @")))(((
",
            TestName = "{m}-4")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
",
            @"6
",
            TestName = "{m}-1")]
        [TestCase(
            @"4 2
",
            @"2
",
            TestName = "{m}-2")]
        [TestCase(
            @"987654 456789
",
            @"778634319
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
