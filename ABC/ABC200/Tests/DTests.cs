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
            const string input = @"5
180 186 189 191 218
";
            const string output = @"Yes
1 1
2 3 4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
123 523
";
            const string output = @"Yes
1 1
1 2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
2013 1012 2765 2021 508 6971
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
