using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CHTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 2
1 2 3 50
2 3 4 45
";
            const string output = @"13
";
            Tester.InOutTest(Tasks.CH.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 2
2 3 6 1152886174205865983
1 2 8 1116611213275394047
";
            const string output = @"395781543
";
            Tester.InOutTest(Tasks.CH.Solve, input, output);
        }
    }
}
