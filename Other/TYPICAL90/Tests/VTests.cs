using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class VTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2 3
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.V.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2 4
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.V.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1000000000000000000 999999999999999999 999999999999999998
";
            const string output = @"2999999999999999994
";
            Tester.InOutTest(Tasks.V.Solve, input, output);
        }
    }
}
