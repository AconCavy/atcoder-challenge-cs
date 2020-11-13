using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 2
8 7 6
rsrpr";
            const string output = @"27";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"7 1
100 10 1
ssssppr";
            const string output = @"211";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"30 5
325 234 123
rspsspspsrpspsppprpsprpssprpsr";
            const string output = @"4996";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
