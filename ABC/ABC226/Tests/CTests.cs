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
            const string input = @"3
3 0
5 1 1
7 1 1
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
1000000000 0
1000000000 0
1000000000 0
1000000000 0
1000000000 4 1 2 3 4
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
