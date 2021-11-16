using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
1 2
2 1
2 3
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 7
2 4
2 8
7 3
6 1
8 4
8 3
5 3
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }
    }
}
