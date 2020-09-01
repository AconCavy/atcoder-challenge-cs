using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
taro
jiro
taro
saburo";
            var output = @"taro";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
takahashikun";
            var output = @"takahashikun";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"9
a
b
c
c
b
c
b
d
e";
            var output = @"b";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
