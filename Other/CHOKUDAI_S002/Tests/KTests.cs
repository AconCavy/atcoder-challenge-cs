using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
58 48
58 58
20 19
58 425
48 425
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1000000000 1000000000
1000000000 1000000000
1000000000 1000000000
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
