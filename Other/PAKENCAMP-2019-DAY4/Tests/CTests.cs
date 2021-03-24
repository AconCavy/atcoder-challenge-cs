using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-5;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 100
10 10
10 10
";
            const string output = @"0.090000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 6
1 6
1 6
";
            const string output = @"‭0.254629629629630
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2212 3741
1725 2601
1644 2479
";
            const string output = @"0.009579046784
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
