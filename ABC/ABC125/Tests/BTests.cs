using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
10 2 5
6 3 4";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
13 21 6 19
11 30 6 15";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1
1
50";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
