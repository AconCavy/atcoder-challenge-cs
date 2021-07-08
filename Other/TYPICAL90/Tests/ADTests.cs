using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ADTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"15 2
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.AD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"30 2
";
            const string output = @"13
";
            Tester.InOutTest(Tasks.AD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"200 4
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.AD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"869120 1
";
            const string output = @"869119
";
            Tester.InOutTest(Tasks.AD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"10000000 3
";
            const string output = @"6798027
";
            Tester.InOutTest(Tasks.AD.Solve, input, output);
        }
    }
}
