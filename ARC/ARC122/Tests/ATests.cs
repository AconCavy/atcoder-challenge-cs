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
            const string input = @"3
3 1 5
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 1 1 1
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
866111664 178537096 844917655 218662351 383133839 231371336 353498483 865935868 472381277 579910117
";
            const string output = @"279919144
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
