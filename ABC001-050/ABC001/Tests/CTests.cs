using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2750 628";
            var output = @"W 5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"161 8";
            var output = @"C 0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3263 15";
            var output = @"NNW 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1462 1959";
            var output = @"SE 12";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"1687 1029";
            var output = @"SSE 8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"2587 644";
            var output = @"WSW 5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = @"113 201";
            var output = @"NNE 3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var input = @"2048 16";
            var output = @"SSW 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
