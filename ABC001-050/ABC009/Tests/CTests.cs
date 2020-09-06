using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
abc";
            var output = @"abc";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 2
atcoder";
            var output = @"actoder";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7 7
atcoder";
            var output = @"acdeort";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10 3
helloworld";
            var output = @"dehloworll";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
