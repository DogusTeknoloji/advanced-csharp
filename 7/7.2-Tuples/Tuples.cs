using static System.Console;

namespace AdvancedCSharp {

    public class Tuples : ITutorial {

        public void Run() {
            (string address, int port) = Helper.ReadOptions();

            WriteLine($"Tuples baby! Address: {address}, port: {port}.");

            (string Alpha, string Beta) namedLetters = ("a", "b");
            WriteLine($"{namedLetters.Alpha}, {namedLetters.Beta}");

            (string, int) holder = ("What", 42);
            WriteLine($"Auto names. Item1: {holder.Item1}, Item2: {holder.Item2}");

            int a = 42, b = 21;
            (a, b) = (b, a);
            WriteLine($"a: {a}, b: {b}");            
        }

        public static class Helper {

            public static (string, int) ReadOptions() {
                return ("http://umutozel.com", 80);
            }
        }
    }
}