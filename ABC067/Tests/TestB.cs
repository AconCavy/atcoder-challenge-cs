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
            var input = @"5 3
1 2 3 4 5";
            var output = @"12";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"15 14
50 26 27 21 41 7 42 35 7 5 5 36 39 1 45";
            var output = @"386";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
