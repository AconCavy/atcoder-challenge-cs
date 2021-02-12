using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
10 80 90 30
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
10 100 10
";
            const string output = @"-80
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
10
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10
1000000000 1 1000000000 1 1000000000 1 1000000000 1 1000000000 1
";
            const string output = @"4999999995
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"6
4 2 9 7 1 5
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
