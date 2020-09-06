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
            var input = "2\nip cc\n";
            var output = "icpc\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "8\nhmhmnknk uuuuuuuu\n";
            var output = "humuhumunukunuku\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "5\naaaaa aaaaa\n";
            var output = "aaaaaaaaaa\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
