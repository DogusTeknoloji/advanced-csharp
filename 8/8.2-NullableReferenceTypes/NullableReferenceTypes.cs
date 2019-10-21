#nullable enable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using static System.Console;

namespace AdvancedCSharp {

    public class NullableReferenceTypes : ITutorial {

        public void Run() {
            Test("Hello, ", "World!");

            // no problem, not nullable
            var doStuff1 = new DoStuff<string, string>();
            // type param should not be nullable
            var doStuff2 = new DoStuff<string?, string>();

            // nice touch, key should not be nullable
            var dict = new Dictionary<int?, string>();

            string[] testArray = { "Hello!", "World!" };
            var value = MyArray.Find<string>(testArray, s => s == "Hello!");
            WriteLine(value.Length); // Warning: Dereference of a possibly null reference.

            MyArray.Resize<string>(ref testArray, 200);
            WriteLine(testArray.Length); // Safe!
        }

        public void Test(string notNullString, string? nullableString) {
            WriteLine(notNullString + nullableString);
        }

        public interface IDoStuff<TIn, TOut>
            where TIn : notnull
            where TOut : notnull {

            TOut Do(TIn input);
        }

        // Warning: CS8714 - Nullability of type argument 'TIn' doesn't match 'notnull' constraint.
        // Warning: CS8714 - Nullability of type argument 'TOut' doesn't match 'notnull' constraint.
        public class DoStuff<TIn, TOut> : IDoStuff<TIn, TOut>
            where TIn : notnull
            where TOut : notnull {

            private string _name = string.Empty;

            public TOut Do(TIn input) {
                throw new NotImplementedException();
            }

            [AllowNull]
            // we allow setting null
            // but always return non-null, so rule isn't broken
            public string Name {
                get {
                    return _name;
                }
                set {
                    _name = value ?? string.Empty;
                }
            }
        }

        public class MyArray {
            // Result is the default of T if no match is found
            [return: MaybeNull]
            public static T Find<T>(T[] array, Func<T, bool> match) {
                return array.FirstOrDefault(match);
            }

            // Never gives back a null when called
            public static void Resize<T>([NotNull] ref T[]? array, int newSize) {
                Array.Resize(ref array, newSize);
            }
        }
    }
}

// https://devblogs.microsoft.com/dotnet/try-out-nullable-reference-types/
