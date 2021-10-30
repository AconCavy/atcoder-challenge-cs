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
            const string input = @"4 3
ode
zaaa
r
atc
";
            const string output = @"atcoder
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2
z
z
zzz
z
zzzzzz
";
            const string output = @"zz
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
