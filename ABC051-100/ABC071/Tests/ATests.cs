using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2 7";
            var output = @"B";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 999 1000";
            var output = @"A";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
