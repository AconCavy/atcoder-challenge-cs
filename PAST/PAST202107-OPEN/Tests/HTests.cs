using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-5;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
0 3 0 0
";
            const string output = @"5.0644951022459797
";
            Tester.InOutTest(Tasks.H.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
0 1 2 3 4 5 0
";
            const string output = @"10.3245553203367599
";
            Tester.InOutTest(Tasks.H.Solve, input, output, RelativeError);
        }
    }
}
