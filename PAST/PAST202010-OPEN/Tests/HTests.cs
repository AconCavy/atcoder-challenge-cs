using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4 3
1123
1214
1810
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 6 40
846444
790187
264253
967004
578258
204367
681998
034243
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
