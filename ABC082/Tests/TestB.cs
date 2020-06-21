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
            var input = @"yx
axy";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"ratcode
atlas";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"cd
abc";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"w
ww";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"zzz
zzz";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
