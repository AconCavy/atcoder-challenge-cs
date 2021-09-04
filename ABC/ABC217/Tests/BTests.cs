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
            const string input = @"ARC
AGC
AHC
";
            const string output = @"ABC
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"AGC
ABC
ARC
";
            const string output = @"AHC
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
