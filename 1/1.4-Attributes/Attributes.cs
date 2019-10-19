using System;

namespace AdvancedCSharp {

    public class Attributes : ITutorial {

        public void Run() {
            var dal = new DAL();
            dal.Save(new User());
            dal.Save(new Product());
            dal.Save(new Company());
            dal.Save(new Customer());
            dal.Save(new Supplier());
        }

        public class LogAttribute : Attribute {
        }

        public class User {
            public string Name { get; set; }
        }

        [Log]
        public class Product {
            public string Code { get; set; }
        }

        [Log]
        public class Company {
            public string Name { get; set; }
            public string Address { get; set; }
        }

        public class Customer : Company {
        }

        public class Supplier : Company {
        }

        public class DAL {

            public void Save(object o) {
                var t = o.GetType();
                if (Attribute.IsDefined(t, typeof(LogAttribute), false)) {
                    Console.WriteLine($"{t} is saved.");
                }
            }
        }
    }
}