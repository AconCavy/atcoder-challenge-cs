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
            const string input = @"5 20
20
5 16
8 -4
3 9
18 2
12 -3
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
