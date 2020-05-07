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
            var input = @"2 5
4 9
2 4";
            var output = @"12";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 30
6 18
2 5
3 10
7 9";
            var output = @"130";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 100000
1000000000 100000";
            var output = @"100000000000000";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
