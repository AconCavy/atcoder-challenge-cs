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
            const string input = @"3 4 2
1 7 7 9
9 6 3 7
7 8 6 4
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 1000000000
1000000 1000000 1
1000000 1000000 1000000
1 1000000 1000000
";
            const string output = @"1001000001
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
