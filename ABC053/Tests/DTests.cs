using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 2 1 3 7";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"15
1 3 5 2 1 3 2 8 8 6 2 6 11 1 1";
            var output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
