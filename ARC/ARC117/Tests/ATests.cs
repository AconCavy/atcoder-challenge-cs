using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        //         [TestMethod, Timeout(TimeLimit)]
        //         public void Test1()
        //         {
        //             const string input = @"1 1
        // ";
        //             const string output = @"1001 -1001
        // ";
        //             Tester.InOutTest(Tasks.A.Solve, input, output);
        //         }

        //         [TestMethod, Timeout(TimeLimit)]
        //         public void Test2()
        //         {
        //             const string input = @"1 4
        // ";
        //             const string output = @"-8 -6 -9 120 -97
        // ";
        //             Tester.InOutTest(Tasks.A.Solve, input, output);
        //         }

        //         [TestMethod, Timeout(TimeLimit)]
        //         public void Test3()
        //         {
        //             const string input = @"7 5
        // ";
        //             const string output = @"323 -320 411 206 -259 298 -177 -564 167 392 -628 151
        // ";
        //             Tester.InOutTest(Tasks.A.Solve, input, output);
        //         }
    }
}
