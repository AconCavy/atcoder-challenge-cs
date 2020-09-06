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
            var input = @"2 2
2 1 2
1 2
0 1";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 3
2 1 2
1 1
1 2
0 0 1";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 2
3 1 2 5
2 2 3
1 0";
            var output = @"8";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
