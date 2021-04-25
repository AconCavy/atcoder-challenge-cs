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
            const string input = @"3
4 4
3 7
8 1
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
12345678 111111111
103050709 20406080
";
            const string output = @"123456789
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
