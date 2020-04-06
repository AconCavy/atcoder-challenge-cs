using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = "4\n10 B\n6 R\n2 R\n4 B\n";
            var output = "2\n6\n4\n10\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "2\n5 B\n7 B\n";
            var output = "5\n7\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
