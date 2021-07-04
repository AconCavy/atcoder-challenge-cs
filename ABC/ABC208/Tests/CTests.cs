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
            const string input = @"2 7
1 8
";
            const string output = @"4
3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 3
33
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 1000000000000
99 8 2 4 43 5 3
";
            const string output = @"142857142857
142857142857
142857142858
142857142857
142857142857
142857142857
142857142857
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
