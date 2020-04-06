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
            var input = "\n";
            var output = "\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
