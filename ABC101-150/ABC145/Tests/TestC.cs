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
0 0
1 0
0 1";
            var output = @"2.2761423749";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
-879 981
-866 890";
            var output = @"91.9238815543";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
-406 10
512 859
494 362
-955 -475
128 553
-986 -885
763 77
449 310";
            var output = @"7641.9817824387";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }
    }
}
