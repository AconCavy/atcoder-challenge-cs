using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BCTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 7 1
1 2 3 4 5 6
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.BC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 1 0
0 0 0 0 0 0 0 0 0 0
";
            const string output = @"252
";
            Tester.InOutTest(Tasks.BC.Solve, input, output);
        }
    }
}
