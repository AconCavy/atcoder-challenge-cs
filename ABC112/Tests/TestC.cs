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
2 3 5
2 1 5
1 2 5
3 2 5";
            var output = @"2 2 6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
0 0 100
1 1 98";
            var output = @"0 0 100";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3
99 1 191
100 1 192
99 0 192";
            var output = @"100 0 193";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
100 100 0";
            var output = @"0 0 200";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
