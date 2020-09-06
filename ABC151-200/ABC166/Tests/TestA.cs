using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"ABC";
            var output = @"ARC";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
