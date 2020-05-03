using Microsoft.VisualStudio.TestTools.UnitTesting;
using E;

namespace Tests
{
    [TestClass]
    public class TestsTemplate
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
2 3 3 1 3 1";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
5 2 4 2 8 8";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"32
3 1 4 1 5 9 2 6 5 3 5 8 9 7 9 3 2 3 8 4 6 2 6 4 3 3 8 3 2 7 9 5";
            var output = @"22";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
