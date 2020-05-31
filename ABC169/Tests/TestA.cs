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
            var input = @"2 5";
            var output = @"10";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

    }
}
