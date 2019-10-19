using System;

namespace AdvancedCSharp {

    public class Nullable : ITutorial {

        public void Run() {
            MyNullable<int> n1 = new MyNullable<int>(5);
            MyNullable<int> n2 = 5;

            Console.WriteLine((int)n1 + (int)n2);
        }

        public struct MyNullable<T> where T : struct {
            private bool hasValue;
            internal T value;

            public MyNullable(T value) {
                this.value = value;
                this.hasValue = true;
            }

            public bool HasValue {
                get {
                    return hasValue;
                }
            }

            public T Value {
                get {
                    if (!hasValue) {
                        throw new InvalidOperationException("Value is null");
                    }

                    return value;
                }
            }

            public T GetValueOrDefault() {
                return value;
            }

            public static implicit operator MyNullable<T>(T value) {
                return new MyNullable<T>(value);
            }

            public static explicit operator T(MyNullable<T> value) {
                return value.Value;
            }
        }
    }
}