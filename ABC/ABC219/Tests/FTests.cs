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
            const string input = @"RDRUL
2
";
            const string output = @"7
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"LR
1000000000000
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"UUURRDDDRRRUUUURDLLUURRRDDDDDDLLLLLLU
31415926535
";
            const string output = @"219911485785
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
