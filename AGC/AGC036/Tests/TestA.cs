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
            var input = @"3";
            var output = @"0 0 1000000000 1 999999997 1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100";
            var output = @"0 0 1000000000 1 999999900 1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"311114770564041497";
            var output = @"0 0 1000000000 1 435958503 311114771";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
