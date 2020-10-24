using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1
2
4
8
9
15";
            const string output = @"Yay!";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"15
18
26
35
36
18";
            const string output = @":(";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
