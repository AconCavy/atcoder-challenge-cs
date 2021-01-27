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
10 10
20 20
30 30
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
20 10
20 20
20 30
";
            const string output = @"20
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
";
            const string output = @"-2999999997
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
