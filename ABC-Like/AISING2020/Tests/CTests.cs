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
            const string input = @"20
";
            const string output = @"0
0
0
0
0
1
0
0
0
0
3
0
0
0
0
0
3
3
0
0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
