using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
BBA
",
            @"Yes
")]
        [TestCase(
            @"4
ABAB
",
            @"No
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2 1
",
            @"2
")]
        [TestCase(
            @"27182818284 59045 23356
",
            @"10752495144
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
