using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"229 390
";
            const string output = @"Hard
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"123456789 9876543210
";
            const string output = @"Easy
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
