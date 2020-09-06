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
            var input = "10 3\n4 5 6\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "20 3\n4 5 6\n";
            var output = "No\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "210 5\n31 41 59 26 53\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = "211 5\n31 41 59 26 53\n";
            var output = "No\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
