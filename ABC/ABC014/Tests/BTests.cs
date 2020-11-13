using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 5
1 10 100 1000";
            var output = @"101";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"20 1048575
1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20";
            var output = @"210";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 0
1000 1000 1000 1000";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
