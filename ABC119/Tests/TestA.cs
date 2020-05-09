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
            var input = @"2019/04/30";
            var output = @"Heisei";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2019/11/01";
            var output = @"TBD";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
