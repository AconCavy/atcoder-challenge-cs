using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"abcabc
2";
            var output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aaaaa
1";
            var output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"hello
10";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"abcde
3";
            var output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
