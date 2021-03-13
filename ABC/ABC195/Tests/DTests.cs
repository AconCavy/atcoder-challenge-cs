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
            const string input = @"3 4 3
1 9
5 3
7 8
1 8 6 9
4 4
1 4
1 3
";
            const string output = @"20
0
9
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
