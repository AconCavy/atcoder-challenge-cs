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
            var input = "3\n1 2 3\n";
            var output = "6\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "10\n3 1 4 1 5 9 2 6 5 3\n";
            var output = "237\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "10\n3 14 159 2653 58979 323846 2643383 27950288 419716939 9375105820\n";
            var output = "103715602\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
