// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Tests
// {
//     [TestClass]
//     public class ATests
//     {
//         const int TimeLimit = 2000;
//         const double RelativeError = 1e-9;

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test1()
//         {
//             const string input = @"3 2
// 00
// 01
// 10
// ";
//             const string output = @"2
// ";
//             Tester.InOutTest(Tasks.A.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test2()
//         {
//             const string input = @"7 5
// 10101
// 00001
// 00110
// 11110
// 00100
// 11111
// 10000
// ";
//             const string output = @"10
// ";
//             Tester.InOutTest(Tasks.A.Solve, input, output);
//         }
//     }
// }
