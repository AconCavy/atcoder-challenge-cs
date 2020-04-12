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
            var input = @"2
ABCXYZ";
            var output = @"CDEZAB";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"0
ABCXYZ";
            var output = @"ABCXYZ";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"13
ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var output = @"NOPQRSTUVWXYZABCDEFGHIJKLM";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
