using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
1 4 8
",
            @"2
")]
        [TestCase(
            @"4
5 10 15 20
",
            @"1
")]
        [TestCase(
            @"10
3785 5176 10740 7744 3999 3143 9028 2822 4748 6888
",
            @"1
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
dpdppd
",
            @"dddpdd
")]
        [TestCase(
            @"3
ddd
",
            @"ddd
")]
        [TestCase(
            @"11
ddpdpdppddp
",
            @"ddddpdpdddp
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
