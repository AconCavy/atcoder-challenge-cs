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
            const string input = @"3
10 11
10 10
-3 -2
";
            const string output = @"0
1
1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
