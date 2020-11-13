using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1 2 10 20 15 200";
            var output = @"110 10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 2 1 2 100 1000";
            var output = @"400 200";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"17 19 22 26 55 2802";
            var output = @"2634 934";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
