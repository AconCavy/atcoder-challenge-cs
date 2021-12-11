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
            const string input = @"5
snuke
snuke
takahashi
takahashi
takahashi
";
            const string output = @"takahashi
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
takahashi
takahashi
aoki
takahashi
snuke
";
            const string output = @"takahashi
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
a
";
            const string output = @"a
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
