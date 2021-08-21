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
            const string input = @"3 12
6 1 5
";
            const string output = @"3
1
7
11
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
