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
            const string input = @"3
3 1
4 108
1 10
";
            const string output = @"255
400
10
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
