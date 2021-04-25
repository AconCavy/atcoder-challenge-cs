using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
6 15
20 19
240 240
555555555 999999999
";
            const string output = @"3
1
240
111111111
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
