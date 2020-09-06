using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3 1 1";
            var output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 7 3 4";
            var output = @"3570";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"100000 100000 99999 99999";
            var output = @"1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"100000 100000 44444 55555";
            var output = @"738162020";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
