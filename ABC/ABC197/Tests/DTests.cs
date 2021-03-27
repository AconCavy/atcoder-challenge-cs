using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-5;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
1 1
2 2
";
            const string output = @"2.00000000000 1.00000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
5 3
7 4
";
            const string output = @"5.93301270189 2.38397459622
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
