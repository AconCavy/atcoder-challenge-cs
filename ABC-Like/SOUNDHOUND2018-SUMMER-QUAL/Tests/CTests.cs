using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 3 1
";
            const string output = @"1.0000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1000000000 180707 0
";
            const string output = @"0.0001807060
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
