using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TestsTemplateTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"";
            var output = @"";
            Tester.InOutTest(() => Tasks.TestsTemplate.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"";
            var output = @"";
            Tester.InOutTest(() => Tasks.TestsTemplate.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"";
            var output = @"";
            Tester.InOutTest(() => Tasks.TestsTemplate.Solve(), input, output);
        }
    }
}
