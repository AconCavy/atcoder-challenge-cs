using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 1
0 0 1
0 1 1
1 0 1
1 1 1
";
            const string output = @"2.000000000000
";
            Tester.InOutTest(Tasks.L.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 1
0 10 1
10 0 2
10 20 3
10 10 1
";
            const string output = @"210.000000000000
";
            Tester.InOutTest(Tasks.L.Solve, input, output, RelativeError);
        }
    }
}
