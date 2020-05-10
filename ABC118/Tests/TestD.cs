using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"20 4
3 7 8 4";
            var output = @"777773";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"101 9
9 8 7 6 5 4 3 2 1";
            var output = @"71111111111111111111111111111111111111111111111111";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"15 3
5 4 6";
            var output = @"654";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
