using static System.Console;

namespace AdvancedCSharp {

    public class StringInterpolation : ITutorial {

        public void Run() {
            var user = new User
            {
                FirstName = "Zaphod",
                LastName = "Beeblebrox",
                Planet = "Betelgeuse V",
                HeadCount = 2
            };

            WriteLine($"My name is {user.FirstName} {user.LastName}, I'm from {user.Planet}. I have {user.HeadCount:F2} heads.");
        }

        public class User {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Planet { get; set; }
            public int HeadCount { get; set; }
        }
    }
}