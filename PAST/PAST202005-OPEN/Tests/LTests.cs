// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Tests
// {
//     [TestClass]
//     public class LTests
//     {
//         const int TimeLimit = 2000;
//         const double RelativeError = 1e-9;

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test1()
//         {
//             const string input = @"2
// 3 1 200 1000
// 5 20 30 40 50 2
// 5
// 1 1 1 2 2
// ";
//             const string output = @"20
// 30
// 40
// 200
// 1000
// ";
//             Tester.InOutTest(Tasks.L.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test2()
//         {
//             const string input = @"10
// 6 8 24 47 29 73 13
// 1 4
// 5 72 15 68 49 16
// 5 65 20 93 64 91
// 6 100 88 63 50 90 44
// 2 6 1
// 10 14 2 76 28 21 78 43 11 97 70
// 5 31 9 62 84 40
// 8 10 46 96 23 98 19 38 51
// 2 37 77
// 20
// 1 1 1 1 2 2 2 1 1 2 2 2 2 2 1 2 1 2 2 1
// ";
//             const string output = @"100
// 88
// 72
// 65
// 93
// 77
// 68
// 63
// 50
// 90
// 64
// 91
// 49
// 46
// 44
// 96
// 37
// 31
// 62
// 20
// ";
//             Tester.InOutTest(Tasks.L.Solve, input, output);
//         }
//     }
// }
