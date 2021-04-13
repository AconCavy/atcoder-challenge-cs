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
            const string input = @"5 10
1 3 5 2 4
";
            const string output = @"Yay!
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 11
3 4
";
            const string output = @":(
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20 23328
2 9 4 7 2 1 5 4 8 1 9 5 6 6 1 9 1 9 8 1
";
            const string output = @"Yay!
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
