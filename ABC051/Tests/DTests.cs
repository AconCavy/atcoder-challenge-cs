using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
1 2 1
1 3 1
2 3 3";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 2
1 2 1
2 3 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
