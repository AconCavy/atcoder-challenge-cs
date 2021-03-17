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
            const string input = @"4
+ 100
- 80
* 3
+ 300
";
            const string output = @"1200
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
- 314
- 159
- 265
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4
* 8
+ 7
* 0
* 5
";
            const string output = @"280
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
