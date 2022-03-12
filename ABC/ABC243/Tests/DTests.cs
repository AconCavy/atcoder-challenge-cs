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
            const string input = @"3 2
URL
";
            const string output = @"6
";
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 500000000000000000
RRUU
";
            const string output = @"500000000000000000
";
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"30 123456789
LRULURLURLULULRURRLRULRRRUURRU
";
            const string output = @"126419752371
";
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
