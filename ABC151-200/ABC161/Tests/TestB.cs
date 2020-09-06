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
            var input = "4 1\n5 4 2 1\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "3 2\n380 19 1\n";
            var output = "No\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "12 3\n4 56 78 901 2 345 67 890 123 45 6 789\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
