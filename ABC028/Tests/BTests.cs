using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"BEAF";
            var output = @"1 1 0 0 1 1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"DECADE";
            var output = @"1 0 1 2 2 0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"ABBCCCDDDDEEEEEFFFFFF";
            var output = @"1 2 3 4 5 6";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
