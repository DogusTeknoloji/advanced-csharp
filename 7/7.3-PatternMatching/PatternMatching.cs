using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace AdvancedCSharp {

    public class PatternMatching : ITutorial {

        public void Run() {
            object o = Helper.GetValue();

            if (o is int) {
                int number1 = (int)o;
                WriteLine($"Too much code! Number: " + number1);
            }

            var number2 = o as int?;
            if (number2 != null) {
                WriteLine($"Too much code! Number: " + number2);
            }

            if (o is int number3) {
                WriteLine($"How cool is this? Number: " + number3);
            }

            var mySeq = new object[] {
                -4, 0, 5, 12,
                new int[] { 4, 9, -3 }
            };
            WriteLine(Helper.SumPositiveNumbers(mySeq));
        }

        public static class Helper {

            public static object GetValue() {
                return 5;
            }

            public static int SumPositiveNumbers(IEnumerable<object> sequence) {
                int sum = 0;
                foreach (var i in sequence) {
                    switch (i) {
                        case IEnumerable<int> childSequence:
                            sum += childSequence.Where(i => i > 0).Sum();
                            break;
                        case int n when n > 0:
                            sum += n;
                            break;
                        default:
                            break;
                    }
                }

                return sum;
            }
        }
    }
}