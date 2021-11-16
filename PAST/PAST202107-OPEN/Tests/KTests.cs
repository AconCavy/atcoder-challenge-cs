using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 5
2 5 7 3
1 2 1
1 3 2
2 4 4
3 4 3
2 3 2
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 5
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
1 2 1000000000
2 3 1000000000
3 4 1000000000
4 5 1000000000
5 6 1000000000
";
            const string output = @"6000000000
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
