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
            var input = @"5
3 2 4 1 2";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
10 71 84 33 6 47 23 25 52 64";
            var output = @"36";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
1 2 3 1000000000 4 5 6";
            var output = @"999999994";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
