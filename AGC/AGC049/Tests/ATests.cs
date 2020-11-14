using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
010
001
010";
            const string output = @"1.66666666666666666667";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
000
000
000";
            const string output = @"3.00000000000000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -9);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3
011
101
110";
            const string output = @"1.00000000000000000000";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output, -9);
        }
    }
}
