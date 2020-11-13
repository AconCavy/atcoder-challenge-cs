using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
2100 2500 2700 2700";
            var output = @"2 2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
1100 1900 2800 3200 3200";
            var output = @"3 5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"20
800 810 820 830 840 850 860 870 880 890 900 910 920 930 940 950 960 970 980 990";
            var output = @"1 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"1
3600";
            var output = @"1 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"2
3200 4800";
            var output = @"1 2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
