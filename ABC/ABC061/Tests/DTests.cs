using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
1 2 4
2 3 3
1 3 5";
            var output = @"7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2 2
1 2 1
2 1 1";
            var output = @"inf";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 5
1 2 -1000000000
2 3 -1000000000
3 4 -1000000000
4 5 -1000000000
5 6 -1000000000";
            var output = @"-5000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
