using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
0 0
0 1
1 1
";
            const string output = @"1.4142135624
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
315 271
-2 -621
-205 -511
-952 482
165 463
";
            const string output = @"1455.7159750446
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
