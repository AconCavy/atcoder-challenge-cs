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
            const string input = @"3
4 1 5
3 10 100
";
            const string output = @"3
7
8
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
100 100 100 100
1 1 1 1
";
            const string output = @"1
1
1
1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4
1 2 3 4
1 2 4 7
";
            const string output = @"1
2
4
7
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8
84 87 78 16 94 36 87 93
50 22 63 28 91 60 64 27
";
            const string output = @"50
22
63
28
44
60
64
27
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
