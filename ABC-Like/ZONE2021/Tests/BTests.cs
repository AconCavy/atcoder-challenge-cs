using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 10 10
3 5
";
            const string output = @"2.857142857142857
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 10 10
3 2
";
            const string output = @"0.0
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 896 483
228 59
529 310
339 60
78 266
659 391
";
            const string output = @"245.3080684596577
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
