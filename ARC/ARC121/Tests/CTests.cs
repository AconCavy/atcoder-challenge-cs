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
            const string input = @"2
5
2 1 3 5 4
2
1 2
";
            const string output = @"2
1 4
0

";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
