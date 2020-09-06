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
            var input = @"2
1 5
2 4
3 6";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
1 1 1
2 2 2
3 3 3";
            var output = @"27";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
3 14 159 2 6 53
58 9 79 323 84 6
2643 383 2 79 50 288";
            var output = @"87";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
