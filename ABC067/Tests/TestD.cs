using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
3 6
1 2
3 1
7 4
5 7
1 4";
            var output = @"Fennec";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 4
4 2
2 3";
            var output = @"Snuke";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
