using static System.Console;

namespace AdvancedCSharp {

    public class Discards : ITutorial {

        public void Run() {
            var town = GetTown();

            (_, _, string country) = ExtractData(town);

            WriteLine($"Country is {country}.");
        }

        public (string name, string city, string country) ExtractData(Town town) {
            return (town?.Name, town?.City?.Name, town?.City?.Country?.Name);            
        }

        public Town GetTown() {
            return new Town {
                Name = "Kadıköy",
                City = new City {
                    Name = "İstanbul",
                    Country = new Country { Name = "Türkiye" }
                }
            };
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