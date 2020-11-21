using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"3 4
1 2 1
2 3 2
3 1 3
1 3 1
";
            const string output = @"1
2
3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
