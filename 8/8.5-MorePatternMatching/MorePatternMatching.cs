using System;
using static System.Console;

namespace AdvancedCSharp {

    public class MorePatternMatching : ITutorial {

        public void Run() {
            var (r, g, b) = Helper.FromColor(Color.Indigo);
            WriteLine($"Indigo RGB is {r}-{b}-{g}");

            var ckale = new Address { Plate = 17 };
            var tax = Helper.ComputeSalesTax(ckale, 1000);
            WriteLine($"Sales tax of 1000 in Çanakkale is {tax}");

            object addr = ckale;
            // woaahh, recursive patterns!
            if (addr is Address { Plate: 17 }) {
                WriteLine("Address is Çanakkale!");
            }
        }

        public static class Helper {

            public static (int, int, int) FromColor(Color color) =>
                // variable name is before switch
                color switch
                {
                    Color.Red => (0xFF, 0x00, 0x00),
                    Color.Orange => (0xFF, 0x7F, 0x00),
                    Color.Yellow => (0xFF, 0xFF, 0x00),
                    Color.Green => (0x00, 0xFF, 0x00),
                    Color.Blue => (0x00, 0x00, 0xFF),
                    Color.Indigo => (0x4B, 0x00, 0x82),
                    Color.Violet => (0x94, 0x00, 0xD3),
                    _ => throw new ArgumentException("Invalid value", nameof(color)),
                };

            // property patterns
            public static decimal ComputeSalesTax(Address location, decimal salePrice) =>
                location switch
                {
                    { Plate: 34 } => salePrice * 0.75M,
                    { Plate: 17 } => salePrice * 0.06M,
                    { Plate: 10 } => salePrice * 0.05M,
                    _ => 0M
                };

            // tuple patterns
            public static string RockPaperScissors(string first, string second)
                => (first, second) switch
                {
                    ("rock", "paper") => "paper wraps rock. paper won.",
                    ("paper", "rock") => "paper wraps rock. paper won.",
                    ("rock", "scissors") => "rock broke scissors. rock won.",
                    ("scissors", "rock") => "rock broke scissors. rock won.",
                    ("paper", "scissors") => "scissors cut paper. scissors won.",
                    ("scissors", "paper") => "scissors cut paper. scissors won.",
                    (_, _) => "draw"
                };

            public static Quadrant GetQuadrant(Point point)
                => point switch
                {
                    var (x, y) when x > 0 && y > 0 => Quadrant.Northeast,
                    var (x, y) when x < 0 && y > 0 => Quadrant.Northwest,
                    var (x, y) when x < 0 && y < 0 => Quadrant.Southwest,
                    var (x, y) when x > 0 && y < 0 => Quadrant.Southeast,
                    var (x, y) when x == 0 || y == 0 => Quadrant.Center,
                    _ => Quadrant.Unknown
                };
        }

        public class Address {
            public int Plate { get; set; }
        }

        public enum Color {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        public class Point {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y) => (X, Y) = (x, y);

            public void Deconstruct(out int x, out int y) =>
                (x, y) = (X, Y);
        }

        public enum Quadrant {
            Unknown,
            Center,
            Southeast,
            Southwest,
            Northwest,
            Northeast
        }
    }
}