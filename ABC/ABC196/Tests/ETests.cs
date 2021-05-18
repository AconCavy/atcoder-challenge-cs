using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
-10 2
10 1
10 3
5
-15 -10 -5 0 5
";
            const string output = @"0
0
5
10
10
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
