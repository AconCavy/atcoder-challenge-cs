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
            var input = @"4
4 7
1 4
5 8
2 5";
            var output = @"6";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 20
2 19
3 18
4 17";
            var output = @"34";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10
457835016 996058008
456475528 529149798
455108441 512701454
455817105 523506955
457368248 814532746
455073228 459494089
456651538 774276744
457667152 974637457
457293701 800549465
456580262 636471526";
            var output = @"540049931";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
