using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 0 0 0
0 0 1 0
0 0 0 0
1 0 0 0
";
            const string output = @"1272
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 1 1 1
1 1 1 1
1 1 1 1
1 1 1 1
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
