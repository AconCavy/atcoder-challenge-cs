using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"17 5
1
5
10
15
16
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"66 10
8
9
16
23
37
47
51
52
53
64
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
