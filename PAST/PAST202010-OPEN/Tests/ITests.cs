using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
10 20 40 30
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"20
13 76 46 15 50 98 93 77 31 43 84 90 6 24 14 37 73 29 43 9
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.I.Solve, input, output);
        }
    }
}
