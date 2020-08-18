using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 60 70
50
10
10
10
10";
            var output = @"2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 50 100
120
-10
-20
-30
70";
            var output = @"2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
