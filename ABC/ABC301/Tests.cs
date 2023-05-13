using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
TTAAT
",
            @"T
",
            TestName = "{m}-1")]
        [TestCase(
            @"6
ATTATA
",
            @"T
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
A
",
            @"A
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
2 5 1 2
",
            @"2 3 4 5 4 3 2 1 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"6
3 4 5 6 5 4
",
            @"3 4 5 6 5 4
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"ch@ku@ai
choku@@i
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"ch@kud@i
akidu@ho
",
            @"Yes
",
            TestName = "{m}-2")]
        [TestCase(
            @"aoki
@ok@
",
            @"No
",
            TestName = "{m}-3")]
        [TestCase(
            @"aa
bb
",
            @"No
",
            TestName = "{m}-4")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"?0?
2
",
            @"1
",
            TestName = "{m}-1")]
        [TestCase(
            @"101
4
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"?0?
1000000000000000000
",
            @"5
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(5000)]
        [TestCase(
            @"3 3 5
S.G
o#o
.#.
",
            @"1
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3 1
S.G
.#o
o#.
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 10 2000000
S.o..ooo..
..o..o.o..
..o..ooo..
..o..o.o..
..o..ooo.G
",
            @"18
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
