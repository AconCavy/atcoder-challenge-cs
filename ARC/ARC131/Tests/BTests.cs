// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace Tests
// {
//     [TestClass]
//     public class BTests
//     {
//         const int TimeLimit = 2000;
//         const double RelativeError = 1e-9;

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test1()
//         {
//             const string input = @"3 3
// ...
// ...
// ...
// ";
//             const string output = @"132
// 313
// 541
// ";
//             Tester.InOutTest(Tasks.B.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test2()
//         {
//             const string input = @"5 7
// 1.2.3.4
// .5.1.2.
// 3.4.5.1
// .2.3.4.
// 5.1.2.3
// ";
//             const string output = @"1425314
// 2531425
// 3142531
// 4253142
// 5314253
// ";
//             Tester.InOutTest(Tasks.B.Solve, input, output);
//         }

//         [TestMethod, Timeout(TimeLimit)]
//         public void Test3()
//         {
//             const string input = @"1 1
// .
// ";
//             const string output = @"4
// ";
//             Tester.InOutTest(Tasks.B.Solve, input, output);
//         }
//     }
// }
