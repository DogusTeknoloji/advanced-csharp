using System;
using System.Linq;
using System.Reflection;

namespace AdvancedCSharp {

    public class Reflection : ITutorial {

        public void Run() {
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetExportedTypes();
            var reflectionType = types.First(t => t.Name == "Reflection");
            Console.WriteLine(reflectionType.GetNestedTypes().Single());

            var company = new Company(1);
            var companyType = typeof(Company);      // company.GetType()

            var companyProps = companyType.GetProperties();
            Console.WriteLine(string.Join(", ", companyProps.Select(p => p.Name)));

            var companyFields = companyType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            Console.WriteLine(string.Join(", ", companyFields.Select(p => p.Name)));
        }

        public class Company {
            private readonly int _id;

            public Company(int id) {
                _id = id;
            }

            public string Name { get; set; }

            public void Save() {
            }
        }
    }
}