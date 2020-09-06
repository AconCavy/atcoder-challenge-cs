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
            var input = @"6 1 2 2
2 1 1 3 0 2";
            var output = @"5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6 1 5 2
2 1 1 3 0 2";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 4 8 5
7 2 3 6 1 6 5 4 6 5";
            var output = @"8";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
