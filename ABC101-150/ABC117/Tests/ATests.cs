using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"8 3";
            const string output = @"2.6666666667";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"99 1";
            const string output = @"99.0000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -3);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 100";
            const string output = @"0.0100000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -3);
        }
    }
}
