using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class APTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.AP.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"234
";
            const string output = @"757186539
";
            Tester.InOutTest(Tasks.AP.Solve, input, output);
        }
    }
}
