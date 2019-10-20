using System;
using static System.Console;

namespace AdvancedCSharp {

    public class NameOf : ITutorial {

        public void Run() {
            try {
                WriteLine("Age: ", Helper.GetAge(null));
            } catch (ArgumentNullException e) {
                WriteLine(e.Message);
            }

            var user = new User();
            try {
                WriteLine("Age: ", Helper.GetAge(user));
            } catch (InvalidOperationException e) {
                WriteLine(e.Message);
            }

            user.BirthYear = 1967;
            WriteLine("Age: " + Helper.GetAge(user));
        }

        public static class Helper {

            public static int GetAge(User user) {
                if (user == null) throw new ArgumentNullException(nameof(user));
                if (user.BirthYear == null) throw new InvalidOperationException($"Cannot calculate when {nameof(user.BirthYear)} is null.");

                return DateTime.Now.Year - user.BirthYear.Value;
            }
        }

        public class User {
            public int? BirthYear { get; set; }
        }
    }
}