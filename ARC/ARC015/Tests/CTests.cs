using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
week 7 day
day 24 hour
hour 60 min
min 60 sec";
            const string output = @"1week=604800sec";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
sic 29 cou
gal 493 cou
gal 17 sic";
            const string output = @"1gal=493cou";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
chou 360 shaku
jou 100 sun
ken 60 sun
li 2160 ken
li 12960 shaku";
            const string output = @"1li=129600sun";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
