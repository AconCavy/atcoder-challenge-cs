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
            var input = @"4
1 2 3 4";
            var output = @"4 2 1 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
1 2 3";
            var output = @"3 1 2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1
1000000000";
            var output = @"1000000000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6
0 6 7 6 7 0";
            var output = @"0 6 6 0 7 7";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
