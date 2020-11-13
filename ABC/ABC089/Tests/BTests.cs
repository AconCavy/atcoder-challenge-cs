using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
G W Y P Y W";
            var output = @"Four";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9
G W W G P W P G G";
            var output = @"Three";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
P Y W G Y W Y Y";
            var output = @"Four";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
