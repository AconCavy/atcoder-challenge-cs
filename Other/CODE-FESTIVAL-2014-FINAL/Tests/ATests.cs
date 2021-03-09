using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"10
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
";
            const string output = @"7.142857142857
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
