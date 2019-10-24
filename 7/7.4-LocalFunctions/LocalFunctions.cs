using System;
using static System.Console;

namespace AdvancedCSharp {

    public class LocalFunctions : ITutorial {

        public void Run() {
            var fact1 = Helper.LambdaFactorial(12);
            WriteLine($"Lambda factorial of 12: {fact1}");

            var fact2 = Helper.LocalFunctionFactorial(12);
            WriteLine($"Local function factorial of 12: {fact2}");
        }

        public static class Helper {

            public static int LambdaFactorial(int n) {
                var nthFactorial = default(Func<int, int>);

                nthFactorial = (number) => 
                    (number < 2) ? 1 : number * nthFactorial(number - 1);

                return nthFactorial(n);
            }

            public static int LocalFunctionFactorial(int n) {
                return nthFactorial(n);

                static int nthFactorial(int number) => 
                    (number < 2) ? 1 : number * nthFactorial(number - 1);
            }
        }
    }
}