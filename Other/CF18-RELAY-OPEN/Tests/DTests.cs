using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
-9 1
-6 1
-4 1
1 1
9 1
10 1
";
            const string output = @"0.500000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"20
-8965725 4915988
-8830129 1578539
-8356752 3503810
-7479989 5100308
-6995994 3722838
-6861764 3493854
-6486775 1657800
-4577872 7994227
-3685008 7178154
-3169623 9319261
-2694681 7493276
-1967934 3837689
-1634671 544297
-1232484 6010778
2733239 4318924
4797695 2789412
5713704 4416095
6609027 2426329
6997023 2155233
7812383 9912027
";
            const string output = @"2249873.278320866637
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
