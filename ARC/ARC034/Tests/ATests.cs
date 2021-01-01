using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-4;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
37 54 68 66 802
58 108 106 103 871
";
            const string output = @"481.4555555555555555
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
80 120 120 120 900
0 0 0 0 731
";
            const string output = @"550
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
