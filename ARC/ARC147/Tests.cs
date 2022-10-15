using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
2 3 6
",
            @"3
")]
        [TestCase(
            @"6
1232 452 23491 34099 57341 21488
",
            @"12
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
3 2 4 1
",
            @"4
A 3
B 1
B 2
B 2
")]
        [TestCase(
            @"3
1 2 3
",
            @"0
")]
        [TestCase(
            @"6
2 1 4 3 6 5
",
            @"3
A 1
A 3
A 5
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
