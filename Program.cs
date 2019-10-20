using System;

namespace AdvancedCSharp {

    class Program {

        static void Main(string[] args) {
            // RunTutorial<Inheritance>();
            // RunTutorial<Events>();
            // RunTutorial<Reflection>();
            // RunTutorial<Attributes>();
            // RunTutorial<Indexers>();

            // RunTutorial<Partial>();
            // RunTutorial<Generics>();
            // RunTutorial<Nullable>();
            // RunTutorial<Iterators>();

            // RunTutorial<AnonTypes>();
            // RunTutorial<ExtensionMethods>();
            // RunTutorial<Lambda>();
            // RunTutorial<Linq>();

            // RunTutorial<Dynamic>();
            // RunTutorial<Variance>();

            // RunTutorial<Async>();
            // RunTutorial<CallerInfo>();

            Console.ReadKey();
        }

        public static void RunTutorial<T>() where T: ITutorial, new() {
            new T().Run();
        }
    }
}
