using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
LRRLR
";
            const string output = @"1 2 4 5 3 0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
LLLLLLL
";
            const string output = @"7 6 5 4 3 2 1 0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
