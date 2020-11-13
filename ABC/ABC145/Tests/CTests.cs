using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
0 0
1 0
0 1";
            const string output = @"2.2761423749";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
-879 981
-866 890";
            const string output = @"91.9238815543";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"8
-406 10
512 859
494 362
-955 -475
128 553
-986 -885
763 77
449 310";
            const string output = @"7641.9817824387";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output, -6);
        }
    }
}
