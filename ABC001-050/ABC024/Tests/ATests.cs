using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"100 200 50 20
40 10";
            var output = @"3500";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"400 1000 400 21
10 10";
            var output = @"14000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"400 1000 400 20
10 10";
            var output = @"6000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
