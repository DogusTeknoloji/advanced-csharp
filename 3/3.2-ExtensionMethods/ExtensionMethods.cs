using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace AdvancedCSharp {

    public class ExtensionMethods : ITutorial {

        public void Run() {
            var user = new User { FirstName = "Douglas", LastName = "Adams" };
            Console.WriteLine(user.FullName());

            var assembly = typeof(User).Assembly;
            foreach (MethodInfo method in assembly.GetExtensionMethods(typeof(User))) {
                Console.WriteLine(method);
            }
        }

        public class User {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public override string ToString() {
                return this.FullName();
            }
        }
    }

    public static class Extensions {

        public static string FullName(this ExtensionMethods.User user) {
            return user.FirstName + " " + user.LastName;
        }

        public static IEnumerable<MethodInfo> GetExtensionMethods(this Assembly assembly, Type extendedType) {
            return from type in assembly.GetTypes()
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                where method.IsDefined(typeof(ExtensionAttribute), false)
                where method.GetParameters()[0].ParameterType == extendedType
                select method;
        }
    }
}
