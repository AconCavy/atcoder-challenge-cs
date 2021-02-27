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
5 2 7 6
1 1 3 1
999999999 1 1000000000 1
";
            const string output = @"20
infinity
1000000000999999999
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
