using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
4980
7980
6980";
            var output = @"15950";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
4320
4320
4320
4320";
            var output = @"15120";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
