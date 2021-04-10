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
            const string input = @"4 3
xx.
...
.xx
.s.
";
            const string output = @"LRR
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
xxx
...
.s.
";
            const string output = @"impossible
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 4
x.xx
.xxx
x.xx
xx.x
xx.x
.s..
";
            const string output = @"RSLLR
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
