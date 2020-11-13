using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"700 600 780";
            var output = @"1300";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10000 10000 10000";
            var output = @"20000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
