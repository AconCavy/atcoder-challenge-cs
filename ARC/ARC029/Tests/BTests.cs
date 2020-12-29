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
            const string input = @"1 6
3
8 3
4 4
5 5
";
            const string output = @"YES
NO
YES
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
