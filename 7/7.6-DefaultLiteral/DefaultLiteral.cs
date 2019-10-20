using static System.Console;

namespace AdvancedCSharp {

    public class DefaultLiterals : ITutorial {

        public void Run() {
            WriteLine($"Old Style: {Helper.OldStyle<decimal>()}");
            WriteLine($"Old Style with args: {Helper.OldStyleWithArgs<decimal>(1, 1)}");

            WriteLine($"New Style: {Helper.OldStyle<decimal>()}");
            WriteLine($"New Style with args: {Helper.OldStyleWithArgs<decimal>(1, 1)}");
        }

        public static class Helper {

            public static bool OldStyle<T>() {
                var i = default(int);
                var o = default(object);
                var t = default(T);

                return i.Equals(o) || i.Equals(t);
            }

            public static bool OldStyleWithArgs<T>(int i = default(int), object o = default(object), T t = default(T)) {
                return i.Equals(o) || i.Equals(t);
            }

            public static bool NewStyle<T>() {
                int i = default;
                object o = default;
                T t = default;

                return i.Equals(o) || i.Equals(t);
            }

            public static bool NewStyleWithArgs<T>(int i = default, object o = default, T t = default) {
                return i.Equals(o) || i.Equals(t);
            }
        }
    }
}