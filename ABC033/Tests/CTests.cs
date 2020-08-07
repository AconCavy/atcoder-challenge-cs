using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"0+0+2*0";
            var output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3*1+1*2";
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"3*1*4+0+2*0+5*2+9*8*6+1+3";
            var output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
