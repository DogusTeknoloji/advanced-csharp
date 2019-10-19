using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp {

    public class Indexers : ITutorial {

        public void Run() {
            var a = new Archive();
            Console.WriteLine(a[2019, 10]);
        }

        public class Archive {
            private readonly Dictionary<DateTime, string> _articles = new Dictionary<DateTime, string>();

            public Archive() {
                _articles.Add(new DateTime(2019, 10, 1), "2019 Ekim");
            }

            public string this[int year, int month] {
                get {
                    var kvp = _articles.FirstOrDefault(a => a.Key.Year == year && a.Key.Month == month);
                    return kvp.Value;
                }
            }
        }
    }
}
