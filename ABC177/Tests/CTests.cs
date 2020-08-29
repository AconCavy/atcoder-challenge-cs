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
1 2 3";
            var output = @"11";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
141421356 17320508 22360679 244949";
            var output = @"437235829";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
1 2 3 4 5";
            // 2 3 4 5 = 14
            // 6 8 10 = 24
            // 12 15 = 27
            // 20
            // 85
            var output = @"85";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3
0 1 2";
            // 0 0
            // 2
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
