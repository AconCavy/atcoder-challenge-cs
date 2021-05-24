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
            const string input = @"(ab)c
";
            const string output = @"abbac
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"past
";
            const string output = @"past
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"(d(abc)e)()
";
            const string output = @"dabccbaeeabccbad
";
            Tester.InOutTest(Tasks.J.Solve, input, output);
        }
    }
}
