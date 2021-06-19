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
1 7 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
1 10 100 1000 10000 100000 1000000 10000000 100000000 1000000000
";
            const string output = @"45
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20
7 8 1 1 4 9 9 6 8 2 4 1 1 9 5 5 5 3 6 4
";
            const string output = @"173
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
