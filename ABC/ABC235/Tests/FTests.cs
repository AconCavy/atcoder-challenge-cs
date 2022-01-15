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
            const string input = @"104
2
0 1
";
            const string output = @"520
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"999
4
1 2 3 4
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890
5
0 2 4 6 8
";
            const string output = @"397365274
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
