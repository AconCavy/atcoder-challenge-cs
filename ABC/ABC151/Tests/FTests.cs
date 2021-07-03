using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
0 0
1 0
";
            const string output = @"0.500000000000000000
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
0 0
0 1
1 0
";
            const string output = @"0.707106781186497524
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
10 9
5 9
2 0
0 0
2 7
3 3
2 5
10 0
3 7
1 9
";
            const string output = @"6.726812023536805158
";
            Tester.InOutTest(Tasks.F.Solve, input, output, RelativeError);
        }
    }
}
