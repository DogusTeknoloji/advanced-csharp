using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedCSharp {

    public class Variance : ITutorial {

        public void Run() {
            IList<string> strings = new List<string>();
            // not allowed
            // IList<object> objects = strings;

            // HEEY?
            IEnumerable<object> objects2 = strings;

            // Covariant => Allows casting to more generic
            // Contravariant => Allows casting to more specific
            // Invariant => Allows none

            var dogs = new Dog[] { new Dog { Age = 2 }, new Dog { Age = 3 } };
            var myZoo = new MyZoo<Animal>(dogs);
            var oldest = myZoo.Oldest();
            Console.WriteLine(oldest);

            Animal cat = new Cat { Age = 12 };
            IWriteOnlyList<Dog> dogList = new WriteOnlyList<Animal>();
            dogList.Add(new Dog { Age = 7 });
        }

        public abstract class Animal {
            public int Age { get; set; }
            public abstract string Species { get; }
        }

        public class Dog : Animal {

            public override string Species { get { return "Dog"; } }
        }

        public class Cat : Animal {

            public override string Species { get { return "Cat"; } }
        }

        public interface IMyZoo<out T> {
            // never takes T => out => covariant
            int Oldest();
        }

        public class MyZoo<T> : IMyZoo<T> where T : Animal {
            private readonly IEnumerable<T> _animals;

            public MyZoo(IEnumerable<T> animals) {
                _animals = animals;
            }

            public int Oldest() {
                return _animals.Max(a => a.Age);
            }
        }

        public interface IWriteOnlyList<in T> {
            // never returns T => in => contravariant
            void Add(T value);
        }

        public class WriteOnlyList<T> : IWriteOnlyList<T> {
            private readonly List<T> _list = new List<T>();

            public void Add(T value) {
                _list.Add(value);
            }
        }
    }
}