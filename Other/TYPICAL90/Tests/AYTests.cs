using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AYTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 2 10
3 8 7 5 11
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.AY.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 1 10
7 7 7 7 7
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.AY.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"40 20 100
1 3 1 3 4 1 3 5 5 3 3 4 1 5 4 4 3 1 3 4 1 3 2 4 4 1 5 2 5 3 1 3 3 3 5 5 5 2 3 5
";
            const string output = @"137846528820
";
            Tester.InOutTest(Tasks.AY.Solve, input, output);
        }
    }
}
