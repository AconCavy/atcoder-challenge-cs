using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 8
3 30
4 50
5 60";
            var output = @"90";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 5
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000";
            var output = @"5000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 15
6 5
5 6
6 4
6 6
3 5
7 2";
            var output = @"17";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
