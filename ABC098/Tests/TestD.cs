using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2 5 4 6";
            var output = @"5";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9
0 0 0 0 0 0 0 0 0";
            var output = @"45";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"19
885 8 1 128 83 32 256 206 639 16 4 128 689 32 8 64 885 969 1";
            var output = @"37";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"9
1 2 3 4 5 6 7 8 9";
            var output = @"12";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
