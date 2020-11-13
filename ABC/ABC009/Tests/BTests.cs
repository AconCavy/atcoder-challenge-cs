using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
100
200
300
300";
            var output = @"200";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
50
370
819
433
120";
            var output = @"433";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
100
100
100
200
200
200";
            var output = @"100";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
