using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 2 6 3";
            var output = @"AOKI";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100 80 100 73";
            var output = @"TAKAHASHI";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"66 30 55 25";
            var output = @"DRAW";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
