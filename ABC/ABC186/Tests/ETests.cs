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
            const string input = @"4
10 4 3
1000 11 2
998244353 897581057 595591169
10000 6 14
";
            const string output = @"2
-1
249561088
3571
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
