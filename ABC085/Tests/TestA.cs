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
            var input = @"2017/01/07";
            var output = @"2018/01/07";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2017/01/31";
            var output = @"2018/01/31";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
