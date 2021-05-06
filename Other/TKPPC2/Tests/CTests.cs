using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 2
1 0 1 0 0 1
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 1
1 1 0 0 1 1 1 0 1 1
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
