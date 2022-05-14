using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"abc
",
            @"abcabc
")]
        [TestCase(
            @"zz
",
            @"zzzzzz
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 10
1 3
",
            @"3
")]
        [TestCase(
            @"2 1
2 3
",
            @"0
")]
        [TestCase(
            @"4 12
3 3 3 3
",
            @"3
")]
        [TestCase(
            @"7 251
202 20 5 1 4 2 100
",
            @"48
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
aaa 10
bbb 20
aaa 30
",
            @"2
")]
        [TestCase(
            @"5
aaa 9
bbb 10
ccc 10
ddd 10
bbb 11
",
            @"2
")]
        [TestCase(
            @"10
bb 3
ba 1
aa 4
bb 1
ba 5
aa 9
aa 2
ab 6
bb 5
ab 3
",
            @"8
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
2 5 3 2 5
",
            @"7
")]
        [TestCase(
            @"20
29 27 79 27 30 4 93 89 44 88 70 75 96 3 78 39 97 12 53 62
",
            @"426
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
