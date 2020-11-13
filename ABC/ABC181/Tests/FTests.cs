using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
0 -40
0 40";
            const string output = @"40";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
0 -10
99 10
0 91
99 -91";
            const string output = @"50.5";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10
-90 40
20 -30
0 -90
10 -70
80 70
-90 30
-20 -80
10 90
50 30
60 -70";
            const string output = @"33.541019662496845446";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"10
65 -90
-34 -2
62 99
42 -13
47 -84
84 87
16 -78
56 35
90 8
90 19";
            const string output = @"35.003571246374276203";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output, -4);
        }
    }
}
