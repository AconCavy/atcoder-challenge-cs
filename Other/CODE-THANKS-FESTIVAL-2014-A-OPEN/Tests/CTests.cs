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
            const string input = @"5 3
100 1 20 14 50
1 2 5
";
            const string output = @"151
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 8
100 100 100 100 100 100 100 100
1 2 3 4 5 6 7 8
";
            const string output = @"800
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
