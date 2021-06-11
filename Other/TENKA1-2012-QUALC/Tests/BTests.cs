using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"CQSAS10SQH10SKSJD3";
            const string output = @"CQH10";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"S10SJSQSKSAC2";
            const string output = @"0";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
