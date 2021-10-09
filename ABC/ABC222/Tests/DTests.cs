using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1 1
2 3
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
2 2 2
2 2 2
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
1 2 3 4 5 6 7 8 9 10
1 4 9 16 25 36 49 64 81 100
";
            const string output = @"978222082
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
