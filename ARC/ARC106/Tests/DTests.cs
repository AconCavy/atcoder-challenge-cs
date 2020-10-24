using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 3
1 2 3";
            const string output = @"12
50
216";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10 10
1 1 1 1 1 1 1 1 1 1";
            const string output = @"90
180
360
720
1440
2880
5760
11520
23040
46080";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 5
1234 5678";
            const string output = @"6912
47775744
805306038
64822328
838460992";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
