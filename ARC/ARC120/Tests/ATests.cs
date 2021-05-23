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
1 2 3
";
            const string output = @"2
8
19
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
