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
            const string input = @"5 4
a*x*
*xx*
*x*b
**cb
****";
            const string output = @"2";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
