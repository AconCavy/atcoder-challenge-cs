using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1
100
30";
            var output = @"2100.000000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
60 50
34 38";
            var output = @"2632.000000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3
12 14 2
6 2 7";
            var output = @"76.000000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
9
10";
            var output = @"20.250000000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"10
64 55 27 35 76 119 7 18 49 100
29 19 31 39 27 48 41 87 55 70";
            var output = @"20291.000000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -3);
        }
    }
}
