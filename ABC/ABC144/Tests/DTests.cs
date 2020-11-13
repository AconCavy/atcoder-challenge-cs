using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 2 4";
            const string output = @"45.0000000000";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"12 21 10";
            const string output = @"89.7834636934";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"3 1 8";
            const string output = @"4.2363947991";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output, -6);
        }
    }
}
