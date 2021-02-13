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
            const string input = @"4 4
1 2
2 4
1 3
3 4
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
1 2
3 5
5 1
3 4
2 3
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
