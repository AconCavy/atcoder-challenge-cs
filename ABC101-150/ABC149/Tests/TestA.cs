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
            var input = "oder atc\n";
            var output = "atcoder\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "humu humu\n";
            var output = "humuhumu\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
