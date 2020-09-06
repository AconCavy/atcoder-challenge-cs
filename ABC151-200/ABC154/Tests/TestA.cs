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
            var input = "red blue\n3 4\nred\n";
            var output = "2 4\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "red blue\n5 5\nblue\n";
            var output = "5 4\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
