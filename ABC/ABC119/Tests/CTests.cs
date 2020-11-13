using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 100 90 80
98
40
30
21
80";
            const string output = @"23";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8 100 90 80
100
100
90
90
90
80
80
80";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"8 1000 800 100
300
333
400
444
500
555
600
666";
            const string output = @"243";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
