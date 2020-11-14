using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestsTemplateTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"";
            const string output = @"";
            Tester.InOutTest(Tasks.TestsTemplate.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"";
            const string output = @"";
            Tester.InOutTest(Tasks.TestsTemplate.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"";
            const string output = @"";
            Tester.InOutTest(Tasks.TestsTemplate.Solve, input, output);
        }
    }
}
