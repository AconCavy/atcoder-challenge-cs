using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1
01
01
10
2
0101
0011
1100
";
            const string output = @"010
11011
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
2
0101
1010
1100
";
            const string output = @"10010";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
