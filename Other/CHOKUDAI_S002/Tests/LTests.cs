using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
3 4
1 5
5 5
3 1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1000000000 1000000000
1000000000 1000000000
1000000000 1
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
