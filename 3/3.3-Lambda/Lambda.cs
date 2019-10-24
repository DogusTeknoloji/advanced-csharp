using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace AdvancedCSharp {

    public class Lambda : ITutorial {
        
        public void Run() {
            var writer1 = new Writer(MyWrite);
            writer1.Write("Hello");
            writer1.ReflectMethod();

            var writer2 = new Writer(delegate (string m) { Console.WriteLine("From Anon Method: " + m); });
            writer2.Write("Hello");
            writer2.ReflectMethod();

            var writer3 = new Writer(m => Console.WriteLine("From Lambda: " + m));
            writer3.Write("Hello");
            writer3.ReflectMethod();

            Action<string> normalLambda = (string message) => Console.WriteLine(message);
            // same syntax, compiler magic!
            Expression<Action<string>> expressionLambda = (string message) => Console.WriteLine(message);
        }

        private static void MyWrite(string message) {
            Console.WriteLine("From MyWrite: " + message);
        }

        public delegate void Write(string message);

        public class Writer {
            private Write _write;

            public Writer(Write write) {
                _write = write;
            }

            public void Write(string message) {
                _write(message);
            }

            public void ReflectMethod() {
                Console.WriteLine("Owner Type: " + _write.Method.DeclaringType.FullName);

                var methods = _write.Method.DeclaringType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);
                Console.WriteLine("Owner Methods: " + string.Join(", ", methods.Select(m => m.Name)));
            }
        }
    }
}
