using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
1 2
2 1
3 4
5 5
3 4
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
