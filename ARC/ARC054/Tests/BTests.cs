using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-8;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3.0000
";
            const string output = @"2.8708930019
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0.0400
";
            const string output = @"0.0400000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1000000000000000000.0000
";
            const string output = @"90.1855078128
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
