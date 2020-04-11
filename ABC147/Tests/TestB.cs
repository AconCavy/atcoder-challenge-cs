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
            var input = "redcoder\n";
            var output = "1\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "vvvvvv\n";
            var output = "0\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "abcdabc\n";
            var output = "2\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
