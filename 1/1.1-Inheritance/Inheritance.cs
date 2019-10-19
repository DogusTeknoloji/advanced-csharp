using System;

namespace AdvancedCSharp {

    public class Inheritance : ITutorial {

        public void Run() {
            var d = new Derived();

            // düzelttikten sonra
            // var b = new Base();
            // Base b_d = d;

            // b.Say();
            // d.Say();
            // b_d.Say();

            // explicit
            // d.YouCannotSeeMe();
        }

        public class Base {

            public Base() {
                Initialize();
            }

            public void Say() {
                Console.WriteLine("Base");
            }

            public virtual void Initialize() {
            }
        }

        public sealed class Derived : Base, IExplicit {
            private string _name;

            public Derived(string name = "Derived") {
                _name = name;
            }

            public new void Say() {
                Console.WriteLine("Derived");
            }

            public sealed override void Initialize() {
                Console.Write(_name.Length);
            }

            void IExplicit.YouCannotSeeMe() {
            }
        }

        public interface IExplicit {

            void YouCannotSeeMe();
        }
    }
}
