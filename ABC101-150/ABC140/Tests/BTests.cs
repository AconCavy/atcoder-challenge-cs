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
3 1 2
2 5 4
3 6";
            const string output = @"14";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
2 3 4 1
13 5 8 24
45 9 15";
            const string output = @"74";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2
1 2
50 50
50";
            const string output = @"150";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
