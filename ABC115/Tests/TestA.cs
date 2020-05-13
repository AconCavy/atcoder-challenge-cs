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
            var input = @"25";
            var output = @"Christmas";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"22";
            var output = @"Christmas Eve Eve Eve";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
