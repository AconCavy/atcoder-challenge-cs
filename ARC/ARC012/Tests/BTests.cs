using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2 1 16";
            const string output = @"2";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100 100 1 100";
            const string output = @"0";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"80 50 49 72";
            const string output = @"14.302717205907";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
