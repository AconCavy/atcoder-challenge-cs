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
3 4 1
7 0 0
0 0 7
0 0 0
1000000000000000 1000000000000000 1000000000000000
";
            const string output = @"2
1
0
0
900000000000000
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
