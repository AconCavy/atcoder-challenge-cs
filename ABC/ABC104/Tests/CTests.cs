using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 700
3 500
5 800";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 2000
3 500
5 800";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 400
3 500
5 800";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"5 25000
20 1000
40 1000
50 1000
30 1000
1 1000";
            const string output = @"66";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
