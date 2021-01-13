using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"-1 -1 2
2 3 4 5
";
            const string output = @"YES
YES
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 1 1
-2 0 4 3
";
            const string output = @"NO
YES
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 0 5
-2 -2 2 1
";
            const string output = @"YES
NO
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"0 0 2
0 0 4 4
";
            const string output = @"YES
YES
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"0 0 5
-4 -4 4 4
";
            const string output = @"YES
YES
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test6()
        {
            const string input = @"0 0 5
-5 -5 5 5";
            const string output = @"NO
YES";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
