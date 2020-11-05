using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3
-30 -10 10 20 50";
            const string output = @"40";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 2
10 20 30";
            const string output = @"20";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 1
0";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"8 5
-9 -7 -4 -3 1 2 3 4";
            const string output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
