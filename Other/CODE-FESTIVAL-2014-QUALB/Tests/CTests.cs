using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"AABCCD
ABEDDA
EDDAAA
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"AAAAAB
CCCCCB
AAABCB
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
