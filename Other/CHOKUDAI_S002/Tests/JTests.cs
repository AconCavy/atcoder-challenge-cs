using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
15 12
18 18
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
999999929 999999883
999999757 999999929
999999883 999999757
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }
    }
}
