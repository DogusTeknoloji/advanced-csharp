using static System.Console;

namespace AdvancedCSharp {

    public class ExpressionBody : ITutorial {

        public void Run() {
            var user = new User { FirstName = "Douglas", LastName = "Adams" };

            WriteLine(user);
        }

        public class User {
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public string FullName => FirstName + " " + LastName;

            public override string ToString() => FullName;
        }
    }
}
