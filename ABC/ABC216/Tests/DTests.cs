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
            const string input = @"2 2
2
1 2
2
1 2
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
2
1 2
2
2 1
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
