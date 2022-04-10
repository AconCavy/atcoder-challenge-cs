using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1011
",
            @"0101
")]
        [TestCase(
            @"0000
",
            @"0000
")]
        [TestCase(
            @"1111
",
            @"0111
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
tanaka taro
tanaka jiro
suzuki hanako
",
            @"Yes
")]
        [TestCase(
            @"3
aaa bbb
xxx aaa
bbb yyy
",
            @"No
")]
        [TestCase(
            @"2
tanaka taro
tanaka taro
",
            @"No
"),]
        [TestCase(
    @"3
takahashi chokudai
aoki kensho
snu ke
",
@"Yes
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
",
            @"1 2 1
")]
        [TestCase(
            @"1
",
            @"1
")]
        [TestCase(
            @"4
",
            @"1 2 1 3 1 2 1 4 1 2 1 3 1 2 1
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 2 3
2 2
1 3 4
2 3
",
            @"4
8
")]
        [TestCase(
            @"2
1 1000000000 1000000000
2 1000000000
",
            @"1000000000000000000
")]
        [TestCase(
            @"5
1 1 1
1 1 1
1 1 1
1 1 1
1 1 1
",
            @"")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 3 1
1 2 3 1
",
            @"4
")]
        [TestCase(
            @"5 2 1
1 3 2 4 1
",
            @"0
")]
        [TestCase(
            @"5 1 1
1 1 1 1 1
",
            @"15
")]
        [TestCase(
            @"10 8 1
2 7 1 8 2 8 1 8 2 8
",
            @"36
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 2 3
2 1 3
",
            @"3
")]
        [TestCase(
            @"5
2 3 5 4 1
4 2 1 3 5
",
            @"12
")]
        [TestCase(
            @"8
1 2 3 4 5 6 7 8
1 2 3 4 5 6 7 8
",
            @"1
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
