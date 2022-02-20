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
            const string input = @"5
3 2 3 2 2
";
            const string output = @"1
2
3
4
3
";
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
2 3 2 3 3 3 2 3 3 2
";
            const string output = @"1
2
3
4
5
3
2
3
1
0
";
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
