using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"azzel
apple";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"chokudai
redcoder";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"abcdefghijklmnopqrstuvwxyz
ibyhqfrekavclxjstdwgpzmonu";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
