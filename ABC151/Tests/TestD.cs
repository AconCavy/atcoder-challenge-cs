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
            var input = "\n";
            var output = "\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
