using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 6
3 1 2 3
2 4 2
2 4 6
1 6
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 4
2 1 2
2 1 2
1 3
2 4 3
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
