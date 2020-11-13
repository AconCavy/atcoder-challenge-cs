using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 10 20";
            const string output = @"30
50
90
170
330
650
1290
2570
5130
10250";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4 40 60";
            const string output = @"200
760
3000
11960
47800
191160
764600
3058360
12233400
48933560";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
