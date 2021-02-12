using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 4
2 3
";
            const string output = @"First
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 5
2 3
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 7
2 3
";
            const string output = @"First
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"3 20
1 2 3
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"3 21
1 2 3
";
            const string output = @"First
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test6()
        {
            const string input = @"1 100000
1
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.K.Solve, input, output);
        }
    }
}
