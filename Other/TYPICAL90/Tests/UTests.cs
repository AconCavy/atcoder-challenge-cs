using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 7
1 2
2 1
2 3
4 3
4 1
1 4
2 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.U.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100 1
1 2
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.U.Solve, input, output);
        }
    }
}
