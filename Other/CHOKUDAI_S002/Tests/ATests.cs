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
3 4
1000000000 1
111111111 111111111
";
            const string output = @"12
1000000000
12345678987654321
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
