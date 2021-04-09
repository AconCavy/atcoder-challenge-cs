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
            const string input = @"2
2 10 20
1 1 1
";
            const string output = @"Yes
No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
