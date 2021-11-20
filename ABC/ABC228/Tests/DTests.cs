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
            const string input = @"4
1 1048577
1 1
2 2097153
2 3
";
            const string output = @"1048577
-1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
