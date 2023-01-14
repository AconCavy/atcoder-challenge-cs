using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
",
            @"110000020
")]
        [TestCase(
            @"882436
",
            @"998244353
")]
        [TestCase(
            @"2023
",
            @"110200222
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 5
abcde
fghij
klmno
pqrst
1
3 3
",
            @"mlkon
hgfji
cbaed
rqpts
")]
        [TestCase(
            @"3 7
atcoder
regular
contest
2
1 1
2 5
",
            @"testcon
oderatc
ularreg
")]
        [TestCase(
            @"2 2
ac
wa
3
1 1
1 1
1 1
",
            @"ac
wa
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
