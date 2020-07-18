using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 1 1
1 2 1
2 1 2
3 3 10";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1 10
10 10 10";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
