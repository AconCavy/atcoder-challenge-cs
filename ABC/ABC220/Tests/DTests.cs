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
            const string input = @"3
2 7 6
";
            const string output = @"1
0
0
0
2
1
0
0
0
0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
0 1 2 3 4
";
            const string output = @"6
0
1
1
4
0
1
1
0
2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
