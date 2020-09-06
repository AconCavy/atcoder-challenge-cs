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
            var input = "4 3\n6 12 6 9\n4 6 3\n";
            var output = "4\n3\n3\n\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "4 3\n4 6 2 1\n3 2 1000000000\n";
            var output = "1\n4\n4\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
