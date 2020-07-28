using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
4
2";
            var output = @"7";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
4
4";
            var output = @"16";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
