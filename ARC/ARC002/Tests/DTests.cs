using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 10
..o.o.xxx.
...o.xo.x.
o.xxo..x..";
            const string output = @"o";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 5
..x..
.o...
...x.";
            const string output = @"x";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
