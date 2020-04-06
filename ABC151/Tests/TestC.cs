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
            var input = "\n";
            var output = "\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
