using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"happy,newyear,enjoy";
            var output = @"happy newyear enjoy";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"haiku,atcoder,tasks";
            var output = @"haiku atcoder tasks";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"abcde,fghihgf,edcba";
            var output = @"abcde fghihgf edcba";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
