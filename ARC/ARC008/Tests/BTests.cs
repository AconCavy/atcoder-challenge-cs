using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"7 26
NAOHIRO
ABCDEFGHIJKLMNOPQRSTUVWXYZ
";
            const string output = @"2";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 8
TAKOYAKI
TAKOYAKI
";
            const string output = @"1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 4
CHOKUDAI
MYON
";
            const string output = @"-1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"6 6
MONAKA
NAMAKO
";
            const string output = @"1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
