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
            const string input = @"0.000 0.000
";
            const string output = @"0 0 1 0
0 0 0 1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0.001 0.001
";
            const string output = @"0 0 1 1
0 1 1 -998
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
