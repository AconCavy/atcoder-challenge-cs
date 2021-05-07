// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Tests
// {
//     [TestClass]
//     public class ETests
//     {
//         const int TimeLimit = 2000;
//         const double RelativeError = 1e-9;

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test1()
//         {
//             const string input = @"3 7 3
// 1 4 9
// ";
//             const string output = @"3
// ";
//             Tester.InOutTest(Tasks.E.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test2()
//         {
//             const string input = @"5 2 3
// 1 4 9
// ";
//             const string output = @"81
// ";
//             Tester.InOutTest(Tasks.E.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test3()
//         {
//             const string input = @"10000 27 7
// 1 3 4 6 7 8 9
// ";
//             const string output = @"989112238
// ";
//             Tester.InOutTest(Tasks.E.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test4()
//         {
//             const string input = @"1000000000000000000 29 6
// 1 2 4 5 7 9
// ";
//             const string output = @"853993813
// ";
//             Tester.InOutTest(Tasks.E.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test5()
//         {
//             const string input = @"1000000000000000000 957 7
// 1 2 3 5 6 7 9
// ";
//             const string output = @"205384995
// ";
//             Tester.InOutTest(Tasks.E.Solve, input, output);
//         }
//     }
// }
