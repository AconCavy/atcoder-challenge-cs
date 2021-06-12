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
3 1 4
";
            const string output = @"1.83333333333333333333
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
866111664 178537096 844917655 218662351 383133839 231371336 353498483 865935868 472381277 579910117
";
            const string output = @"362925658.10000000000000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
