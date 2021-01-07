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
            const string input = @"4 100
30 50
40 40
50 100
60 80
";
            const string output = @"190
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 100
40 10
30 50
60 80
20 40
20 70
";
            const string output = @"200
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 654
76 54
62 19
8 5
29 75
28 4
76 16
96 24
79 30
20 64
23 56
";
            const string output = @"347
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
