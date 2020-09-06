using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
acornistnt
peanutbomb
constraint";
            var output = @"1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2
oneplustwo
ninemodsix";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
abaaaaaaaa
oneplustwo
aaaaaaaaba
twoplusone
aaaabaaaaa";
            var output = @"4";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
