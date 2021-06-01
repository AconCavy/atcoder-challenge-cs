using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"CODEFESTIVAL";
            const string output = @"CODEFESTIVAL2014";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"CHOKUDAI";
            const string output = @"CHOKUDAI2014";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
