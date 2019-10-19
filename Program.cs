using System;

namespace AdvancedCSharp {

    class Program {

        static void Main(string[] args) {
            // RunTutorial<Inheritance>();
            // RunTutorial<Events>();
            // RunTutorial<Reflection>();
            RunTutorial<Attributes>();

            Console.ReadKey();
        }

        public static void RunTutorial<T>() where T: ITutorial, new() {
            new T().Run();
        }
    }
}
