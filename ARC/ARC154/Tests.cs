using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2
13
22
",
            @"276
",
            TestName = "{m}{i}")]
        [TestCase(
            @"8
20220122
21002300
",
            @"54558365
",
            TestName = "{m}{i}")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
abab
abba
",
            @"2
",
            TestName = "{m}{i}")]
        [TestCase(
            @"3
arc
cra
",
            @"2
",
            TestName = "{m}{i}")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
