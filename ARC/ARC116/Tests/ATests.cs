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
            const string input = @"4
2
998244353
1000000000000000000
10
";
            const string output = @"Same
Odd
Even
Same
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
