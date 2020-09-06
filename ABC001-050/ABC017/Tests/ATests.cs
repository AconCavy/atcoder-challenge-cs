using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"50 7
40 8
30 9";
            var output = @"94";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"990 10
990 10
990 10";
            var output = @"2970";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
