using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 10
6 1 2 7";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 5
3 3 3";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10 53462
103 35322 232 342 21099 90000 18843 9010 35221 19352";
            const string output = @"36";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
