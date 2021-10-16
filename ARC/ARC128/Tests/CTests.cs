using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2 3
1 2 3
";
            const string output = @"8.00000000000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 2
5 1 1
";
            const string output = @"4.66666666666666666667
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 234567 1000000
353239 53676 45485 617014 886590 423581 172670 928532 312338 981241
";
            const string output = @"676780145098.25000000000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
