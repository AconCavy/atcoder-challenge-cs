using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"atcoder
";
            const string output = @"atcoderb
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"abc
";
            const string output = @"abcd
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"zyxwvutsrqponmlkjihgfedcba
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"abcdefghijklmnopqrstuvwzyx
";
            const string output = @"abcdefghijklmnopqrstuvx
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
