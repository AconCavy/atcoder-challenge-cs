using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"31 9 24 31 24
",
            @"3
")]
        [TestCase(
            @"0 0 0 0 0
",
            @"1
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"atco
atcoder
",
            @"Yes
")]
        [TestCase(
            @"code
atcoder
",
            @"No
")]
        [TestCase(
            @"abc
abc
",
            @"Yes
")]
        [TestCase(
    @"aaaa
aa
",
    @"No
"
)]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 2 0 3
",
            @"4
")]
        [TestCase(
            @"3
0 1 2
",
            @"3
")]
        [TestCase(
            @"10
3 9 6 1 7 2 8 0 5 4
",
            @"5
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 1
chokudai
chokudai
",
            @"-1
")]
        [TestCase(
            @"2 2
choku
dai
chokudai
choku_dai
",
            @"dai_choku
")]
        [TestCase(
            @"2 2
chokudai
atcoder
chokudai_atcoder
atcoder_chokudai
",
            @"-1
")]
        [TestCase(
            @"4 4
ab
cd
ef
gh
hoge
fuga
____
_ab_cd_ef_gh_
",
            @"ab__ef___cd_gh
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
