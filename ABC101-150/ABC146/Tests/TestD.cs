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
            var input = @"";
            var output = @"";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
