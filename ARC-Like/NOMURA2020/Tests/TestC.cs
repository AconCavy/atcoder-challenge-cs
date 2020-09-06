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
0 1 1 2";
            var output = @"7";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
0 0 1 0 2";
            var output = @"10";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
0 3 1";
            var output = @"-1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
1 1";
            var output = @"-1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"10
0 0 1 1 2 3 5 8 13 21 34";
            var output = @"264";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"10
0 0 0 0 0 0 0 0 0 0 1024";
            var output = @"2047";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
