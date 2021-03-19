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
            const string input = @"5 400
300 700 1000 800 500
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 1000
2000 2000 4000
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 314159265
358979323 846264338 327950288 419716939 93751058 209749445
";
            const string output = @"7
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
