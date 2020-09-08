using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
1148-1210
1323-1401
1106-1123
1129-1203";
            var output = @"1105-1210
1320-1405";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
0000-2400";
            var output = @"0000-2400";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
1157-1306
1159-1307
1158-1259
1230-1240
1157-1306
1315-1317";
            var output = @"1155-1310
1315-1320";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3
0054-1150
1158-1159
1204-1201";
            var output = @"0050-1150
1155-1205";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
