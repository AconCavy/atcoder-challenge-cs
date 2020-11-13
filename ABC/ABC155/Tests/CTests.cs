using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
beat
vet
beet
bed
vet
bet
beet";
            var output = @"beet
vet";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"8
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo
buffalo";
            var output = @"buffalo";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
bass
bass
kick
kick
bass
kick
kick";
            var output = @"kick";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"4
ushi
tapu
nichia
kun";
            var output = @"kun
nichia
tapu
ushi";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
