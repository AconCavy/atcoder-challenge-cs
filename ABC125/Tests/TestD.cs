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
            var input = @"3
-10 5 -4";
            var output = @"19";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
10 -4 -8 -11 3";
            var output = @"30";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"11
-1000000000 1000000000 -1000000000 1000000000 -1000000000 0 1000000000 -1000000000 1000000000 -1000000000 1000000000";
            var output = @"10000000000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
