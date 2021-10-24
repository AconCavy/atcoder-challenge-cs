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
            const string input = @"6 3
2 0 2 -1 0 -4
";
            const string output = @"4
1
1
-5
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
