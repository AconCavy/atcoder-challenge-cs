using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 3";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"123 456";
            var output = @"210368064";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
