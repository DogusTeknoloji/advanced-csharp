using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp {

    public class AnonTypes : ITutorial {

        public void Run() {
            var companies = new List<Company>();
            var companyDtos = companies.Select(c => new { c.Id, c.Name }).ToList();

            var compCollType = companyDtos.GetType();
            var compAnonType = compCollType.GetGenericArguments().First();
            Console.WriteLine("Company Anon Type: " + compAnonType);

            var users = new List<User>();
            var userDtos = users.Select(c => new { c.Id, c.Name }).ToList();

            var userCollType = userDtos.GetType();
            var userAnonType = userCollType.GetGenericArguments().First();
            Console.WriteLine("User Anon Type: " + userAnonType);

            Console.WriteLine("Are Anon Types Equal? " + (compAnonType.Equals(userAnonType)).ToString());
        }

        public class Company {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
        }

        public class User {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
