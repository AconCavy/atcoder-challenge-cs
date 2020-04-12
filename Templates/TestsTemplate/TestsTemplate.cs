using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestsTemplate
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
