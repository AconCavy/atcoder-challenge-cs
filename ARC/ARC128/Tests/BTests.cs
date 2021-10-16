using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
1 2 2
1 2 3
1 2 4
";
            const string output = @"2
-1
4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
