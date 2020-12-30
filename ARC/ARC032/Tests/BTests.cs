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
            const string input = @"4 2
1 2
1 3
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 4
1 2
2 3
1 3
5 6
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
