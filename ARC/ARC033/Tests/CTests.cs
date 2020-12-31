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
            const string input = @"5
1 11
1 29
1 89
2 2
2 2";
            const string output = @"29
89";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"12
1 8932
1 183450
1 34323
1 81486
1 127874
1 114850
1 55277
1 112706
2 3
1 39456
1 52403
2 4";
            const string output = @"55277
52403";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
