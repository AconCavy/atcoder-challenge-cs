using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
acornistnt
peanutbomb
constraint";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
oneplustwo
ninemodsix";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5
abaaaaaaaa
oneplustwo
aaaaaaaaba
twoplusone
aaaabaaaaa";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
