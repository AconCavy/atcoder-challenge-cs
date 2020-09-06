using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class KTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 4
2 3";
            var output = @"First";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 5
2 3";
            var output = @"Second";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2 7
2 3";
            var output = @"First";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3 20
1 2 3";
            var output = @"Second";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"3 21
1 2 3";
            var output = @"First";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"1 100000
1";
            var output = @"Second";
            Tester.InOutTest(() => Tasks.K.Solve(), input, output);
        }
    }
}
