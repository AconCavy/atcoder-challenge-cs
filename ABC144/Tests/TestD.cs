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
            var input = @"2 2 4";
            var output = @"45.0000000000";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"12 21 10";
            var output = @"89.7834636934";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3 1 8";
            var output = @"4.2363947991";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }
    }
}
