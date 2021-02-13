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
            const string input = @"5
2 6
0 0
1000000 1000000
12345 67890
0 1000000
";
            const string output = @"6
1
0
933184801
500001500001
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
