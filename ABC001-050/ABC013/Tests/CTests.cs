using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4 5
100 4 60 1 4";
            var output = @"160";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 1
5000 2 2000 1 300";
            var output = @"20000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"9 23
170 8 120 5 12";
            var output = @"650";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"653 314159
6728 123456 5141 41928 222222";
            var output = @"2818162";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"10 1000
100 1 200 3 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
