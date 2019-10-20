using static System.Console;

namespace AdvancedCSharp {

    public class PrivateProtected : ITutorial {

        public void Run() {
            WriteLine("Private Protected members can only be accessed derived classes within same Assembly.");
        }

        public class EntityBase {
            protected internal int ProtectedInternalValue = 0;
            protected int ProtectedValue = 0;
            private protected int PrivateProtectedValue = 0;
        }

        public class Order : EntityBase {

            public void Calculate(EntityBase other) {
                other.ProtectedInternalValue = 42;

                // cannot be accessed
                // other.ProtectedValue = 42;
                // other.PrivateProtectedValue = 42;

                base.ProtectedInternalValue = 42;
                base.ProtectedValue = 42;
                base.PrivateProtectedValue = 42;
            }
        }
    }
}

namespace LetsSayThisIsAnotherAssembly {
    using static AdvancedCSharp.PrivateProtected;

    public class Purchase : EntityBase {

        public void Calculate(EntityBase other) {
            other.ProtectedInternalValue = 42;

            // cannot be accessed
            // other.ProtectedValue = 42;
            // other.PrivateProtectedValue = 42;

            base.ProtectedInternalValue = 42;
            base.ProtectedValue = 42;

            // cannot be accessed
            base.PrivateProtectedValue = 42;
        }
    }
}