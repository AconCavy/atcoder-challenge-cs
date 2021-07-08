using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AXTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.AX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.AX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 2
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.AX.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"6783 125
";
            const string output = @"674508908
";
            Tester.InOutTest(Tasks.AX.Solve, input, output);
        }
    }
}
