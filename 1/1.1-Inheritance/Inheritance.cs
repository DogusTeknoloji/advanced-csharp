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

        public class Derived : Base {
            private string _name;

            public Derived(string name = "Derived") {
                _name = name;
            }

            public new void Say() {
                Console.WriteLine("Derived");
            }

            public override void Initialize() {
                Console.Write(_name.Length);
            }
        }
    }
}
