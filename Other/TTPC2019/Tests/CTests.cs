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
            const string input = @"4 11
8 -1 1 5
";
            const string output = @"8 7 1 5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 7
-1 2 -1 4 -1 6
";
            const string output = @"7 2 0 4 0 6
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 2
3
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
