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
            var input = @"3 2
1 2 3";
            var output = @"2 3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 10
1 2 3 2 3";
            var output = @"3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 1000000000000
1 1 2 2 3 3";
            var output = @"";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"11 97
3 1 4 1 5 9 2 6 5 3 5";
            var output = @"9 2 6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
