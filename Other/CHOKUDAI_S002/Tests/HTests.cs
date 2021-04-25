using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
3 5
1 1
";
            const string output = @"2
-1
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
