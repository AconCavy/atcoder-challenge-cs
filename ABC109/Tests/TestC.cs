using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
1 7 11";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 81
33 105 57";
            var output = @"24";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 1
1000000000";
            var output = @"999999999";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
