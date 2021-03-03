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
            const string input = @"15 10
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snuke snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
snake snake snake snake snake snake snake snake snake snake
";
            const string output = @"H6
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 1
snuke
";
            const string output = @"A1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
