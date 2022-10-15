using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
1 4 3 5 8
",
            @"854
")]
        [TestCase(
            @"8
813 921 481 282 120 900 555 409
",
            @"921900813
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 8 2
1 2 4 8
",
            @"10
")]
        [TestCase(
            @"5 345 3
111 192 421 390 229
",
            @"461
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
