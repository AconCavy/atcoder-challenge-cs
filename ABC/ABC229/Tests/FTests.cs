using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
31 4 159 2 65
5 5 5 5 10
";
            const string output = @"16
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
100 100 100 1000000000
1 2 3 4
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
