using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CDTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 5
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.CD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"98 100
";
            const string output = @"694
";
            Tester.InOutTest(Tasks.CD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1001 869120
";
            const string output = @"59367733
";
            Tester.InOutTest(Tasks.CD.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"381453331666495446 746254773042091083
";
            const string output = @"584127830
";
            Tester.InOutTest(Tasks.CD.Solve, input, output);
        }
    }
}
