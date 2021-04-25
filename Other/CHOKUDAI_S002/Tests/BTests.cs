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
            const string input = @"3
10 3
1000000000 1
11 92
";
            const string output = @"1
0
11
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
