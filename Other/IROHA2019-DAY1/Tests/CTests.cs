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
            const string input = @"21
";
            const string output = @"14
15
16
17
18
19
20
21
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8
";
            const string output = @"1
2
3
4
5
6
7
8
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
