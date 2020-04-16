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
            var input = @"3
2 3 1";
            var output = @"3 1 2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
1 2 3 4 5";
            var output = @"1 2 3 4 5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
8 2 7 3 4 5 6 1";
            var output = @"8 2 4 5 6 7 3 1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
