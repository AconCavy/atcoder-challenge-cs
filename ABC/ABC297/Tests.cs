using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 500
300 900 1300 1700
",
            @"1300
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 99
100 200 300 400 500
",
            @"-1
",
            TestName = "{m}-2")]
        [TestCase(
            @"4 500
100 600 1100 1600
",
            @"600
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"RNBQKBNR
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"KRRBBNNQ
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"BRKRBQNN
",
            @"No
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 8
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"1234567890 1234567890
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"1597 987
",
            @"15
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"4 6
20 25 30 100
",
            @"50
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 10
2 1
",
            @"10
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 200000
955277671 764071525 871653439 819642859 703677532 515827892 127889502 881462887 330802980 503797872
",
            @"5705443819
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2 2
",
            @"665496238
",
            TestName = "{m}-1")]
        [TestCase(
            @"10 10 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"314 159 2653
",
            @"639716353
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 1 2
2 3 3
",
            @"First
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 1 1
3 1 4 1 5
",
            @"Second
",
            TestName = "{m}-2")]
        [TestCase(
            @"7 3 14
10 20 30 40 50 60 70
",
            @"First
",
            TestName = "{m}-3")]
        public void GTest(string input, string output)
        {
            Utility.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
