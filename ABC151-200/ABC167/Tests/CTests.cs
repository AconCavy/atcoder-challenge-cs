using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 3 10
60 2 2 4
70 8 7 9
50 2 3 9";
            const string output = @"120";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 3 10
100 3 1 4
100 1 5 9
100 2 6 5";
            const string output = @"-1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"8 5 22
100 3 7 5 3 1
164 4 5 2 7 8
334 7 2 7 2 9
234 4 7 2 8 2
541 5 4 3 3 6
235 4 8 6 9 7
394 3 6 1 6 2
872 8 4 3 7 2";
            const string output = @"1067";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
