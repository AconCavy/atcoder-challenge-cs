using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
cbaa
daacc
acacac";
            var output = @"aac";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
a
aa
b";
            var output = @"
";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
