using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"7
nikoandsolstice";
            const string output = @"nikoand...";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"40
ferelibenterhominesidquodvoluntcredunt";
            const string output = @"ferelibenterhominesidquodvoluntcredunt";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
