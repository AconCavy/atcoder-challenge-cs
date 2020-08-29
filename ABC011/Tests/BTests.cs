using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"taKahAshI";
            var output = @"Takahashi";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"A";
            var output = @"A";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
