using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"7
adbabcd
abc
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
ababaa
aba
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
zzzzzz
abc
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
