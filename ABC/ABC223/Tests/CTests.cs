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
            const string input = @"3
1 1
2 1
3 1
";
            const string output = @"3.000000000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 3
2 2
3 1
";
            const string output = @"3.833333333333333
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
3 9
1 2
4 6
1 5
5 3
";
            const string output = @"8.916666666666668
";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
