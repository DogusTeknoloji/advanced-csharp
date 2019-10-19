using System;
using System.Collections.Generic;
using System.Dynamic;

namespace AdvancedCSharp {

    public class Dynamic : ITutorial {

        public void Run() {
            var user = new User { Id = 42, UserName = "Douglas Adams" };
            var company = new Company { Id = 13, Name = "Microsoft" };

            dynamic dyn = user;
            Console.WriteLine(dyn.Id);

            // reflection used behind the curtains
            dyn = company;
            Console.WriteLine(dyn.Id);

            dynamic expando = new ExpandoObject();
            expando.Id = 21;
            expando.Name = "Sylvester Stallone";
            expando.SayName = new Action(() => Console.WriteLine("Addriaaannn"));

            expando.SayName();

            foreach (var kvp in (IDictionary<string, object>)expando) {
                Console.WriteLine("Prop: " + kvp.Key + ", Value: " + kvp.Value);
            }
        }

        public class User {
            public int Id { get; set; }

            public string UserName { get; set; }
        }

        public class Company {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}