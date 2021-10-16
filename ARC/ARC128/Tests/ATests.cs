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
3 5 2
";
            const string output = @"0 1 1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 1 1 1
";
            const string output = @"0 0 0 0
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
426877385 186049196 624834740 836880476 19698398 709113743 436942115 436942115 436942115 503843678
";
            const string output = @"1 1 0 1 1 1 0 0 1 0
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
