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
            var input = @"7
nikoandsolstice";
            var output = @"nikoand...";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"40
ferelibenterhominesidquodvoluntcredunt";
            var output = @"ferelibenterhominesidquodvoluntcredunt";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
