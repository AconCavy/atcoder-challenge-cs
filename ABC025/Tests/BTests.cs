using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5 10
East 7
West 3
West 11";
            var output = @"West 8";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3 8
West 6
East 3
East 1";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 25 25
East 1
East 1
West 1
East 100
West 1";
            var output = @"East 25";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
