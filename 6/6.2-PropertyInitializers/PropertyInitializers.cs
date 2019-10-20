using System.Collections.Generic;
using static System.Console;

namespace AdvancedCSharp {

    public class PropertyInitializers : ITutorial {

        public void Run() {
            WriteLine("Addresses is set: " + new Company().Addresses);
        }

        public class Company {
            public int Id { get; set; }
            // readonly! can only be set in ctor, or ...
            public List<Address> Addresses { get; } = new List<Address>();
        }

        public class Address {
            public string City { get; set; }
        }
    }
}