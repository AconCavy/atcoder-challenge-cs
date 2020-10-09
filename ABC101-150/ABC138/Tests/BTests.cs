using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
10 30";
            const string output = @"7.5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
200 200 200";
            const string output = @"66.66666666666667";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1
1000";
            const string output = @"1000";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -5);
        }
    }
}
