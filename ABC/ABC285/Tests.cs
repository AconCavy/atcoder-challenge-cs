using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 2
",
            @"Yes
")]
        [TestCase(
            @"2 8
",
            @"No
")]
        [TestCase(
            @"14 15
",
            @"No
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
abcbac
",
            @"5
1
2
0
1
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"AB
",
            @"28
")]
        [TestCase(
            @"C
",
            @"3
")]
        [TestCase(
            @"BRUTMHYHIIZP
",
            @"10000000000000000
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
b m
m d
",
            @"Yes
")]
        [TestCase(
            @"3
a b
b c
c a
",
            @"No
")]
        [TestCase(
            @"5
aaa bbb
yyy zzz
ccc ddd
xxx yyy
bbb ccc
",
            @"Yes
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7
10 10 1 1 1 1 1
",
            @"50
")]
        [TestCase(
            @"10
200000000 500000000 1000000000 800000000 100000000 80000000 600000 900000000 1 20
",
            @"5100000000
")]
        [TestCase(
            @"20
38 7719 21238 2437 8855 11797 8365 32285 10450 30612 5853 28100 1142 281 20537 15921 8945 26285 2997 14680
",
            @"236980
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
abcdcf
4
2 1 3
2 2 6
1 5 e
2 2 6
",
            @"Yes
No
Yes
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
