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
            var input = @"5 3 11
1";
            var output = @"30";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3 4
2";
            var output = @"22";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
