using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"takahashi";
            var output = @"tak";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"naohiro";
            var output = @"nao";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
