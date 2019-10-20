using System;
using static System.Console;

namespace AdvancedCSharp {

    public class ReadonlyMembers : ITutorial {

        public void Run() {
            WriteLine("Adding C# more functional language properties!");
            WriteLine("With readonly members, C# Compiler can enforce us to write pure functions!");
        }

        public struct Point {
            public double X { get; set; }
            public double Y { get; set; }
            public readonly double Distance => Math.Sqrt(X * X + Y * Y);

            public override readonly string ToString() =>
                $"({X}, {Y}) is {Distance} from the origin";
        }
    }
}