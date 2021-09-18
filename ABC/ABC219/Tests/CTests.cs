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
            const string input = @"bacdefghijklmnopqrstuvwxzy
4
abx
bzz
bzy
caa
";
            const string output = @"bzz
bzy
abx
caa
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"zyxwvutsrqponmlkjihgfedcba
5
a
ab
abc
ac
b
";
            const string output = @"b
a
ac
ab
abc
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
