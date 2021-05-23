using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
10 10 -10 -10 -10
10 -10 -10 -10
-10 -10 -10
10 -10
-10
";
            const string output = @"40
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 1
1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
