using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 10 20";
            var output = @"30
50
90
170
330
650
1290
2570
5130
10250";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 40 60";
            var output = @"200
760
3000
11960
47800
191160
764600
3058360
12233400
48933560";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
