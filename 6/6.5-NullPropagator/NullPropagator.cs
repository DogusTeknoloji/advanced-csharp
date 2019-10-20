using static System.Console;

namespace AdvancedCSharp {

    public class NullPropagator : ITutorial {

        public void Run() {
            var town1 = new Town();
            var town2 = new Town {
                Name = "Kadıköy",
                City = new City {
                    Name = "İstanbul",
                    Country = new Country { Name = "Türkiye" }
                }
            };
            WriteCountry(town1);
            WriteCountry(town2);
        }

        public void WriteCountry(Town town) {
            string country = null;
            if (town != null & town.City != null && town.City.Country != null) {
                country = town.City.Country.Name;
            }
            WriteLine("Bleh, old way sucks: " + country);

            WriteLine("Null conditional rules: " + town?.City?.Country?.Name);
        }

        public class Country {
            public string Name { get; set; }
        }

        public class City {
            public string Name { get; set; }
            public Country Country { get; set; }
        }

        public class Town {
            public string Name { get; set; }
            public City City { get; set; }
        }
    }
}