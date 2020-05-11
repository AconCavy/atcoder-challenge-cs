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
            var input = @"8 3";
            var output = @"2.6666666667";
            Tester.InOutTest(() => Program.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"99 1";
            var output = @"99.0000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 100";
            var output = @"0.0100000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -3);
        }
    }
}
