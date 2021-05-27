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
            const string input = @"10 3
3 5 2 6
3 5 3 4
3 5 7 10
";
            const string output = @"200
0
300
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100000 5
30000 50000 12345 67890
50000 50001 50000 50002
1 100000 9384 99384
1 2 3 100000
48592 84911 58124 91852
";
            const string output = @"3554500
100
0
9999700
694100
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
